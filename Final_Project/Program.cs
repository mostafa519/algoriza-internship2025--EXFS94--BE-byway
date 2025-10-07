using Asp.Versioning;
using AutoMapper;
using ByWay.DomainLayer.Model;
using ByWay.DomainLayer.ModelAuth;
using ByWay.RepositoryLayer;
using ByWay.RepositoryLayer.Helper;
using ByWay.ServicesLayer.Mapping;
using ByWay.ServicesLayer.Service;
using ByWay.ServicesLayer.Service.Contact_Interface;
using ByWay.ServicesLayer.Service.Implementation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// ---------------- JWT Configuration ----------------
builder.Services.Configure<JWTClass>(configuration.GetSection("JWT"));

// ---------------- DbContext ----------------
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.MigrationsAssembly("ByWay.RepositoryLayer")
    )
    .ConfigureWarnings(warnings =>
        warnings.Ignore(RelationalEventId.PendingModelChangesWarning))
);

// ---------------- Identity ----------------
builder.Services.AddIdentity<Student, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 8;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// ---------------- CORS (Allow All) ----------------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// ---------------- AutoMapper ----------------
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MappingCourse>();
    cfg.AddProfile<MappingInstructor>();
    cfg.AddProfile<MappingProfile>();
});

// ---------------- Upload Path ----------------
builder.Services.AddSingleton(sp =>
{
    var env = sp.GetRequiredService<IWebHostEnvironment>();
    var path = Path.Combine(env.WebRootPath ?? env.ContentRootPath, "Uploads");
    if (!Directory.Exists(path))
        Directory.CreateDirectory(path);
    return path;
});

// ---------------- Scoped Services ----------------
builder.Services.AddScoped<ICourse, CourseServices>();
builder.Services.AddScoped<ICategory, CategoryService>();
builder.Services.AddScoped<IFavoriteCourseService, FavoriteCourseService>();
builder.Services.AddScoped<IStudentProfileService, StudentProfileService>();
builder.Services.AddScoped<IInstructor, InstructorServices>();
builder.Services.AddScoped<IAuthService>(sp =>
{
    var userManager = sp.GetRequiredService<UserManager<Student>>();
    var roleManager = sp.GetRequiredService<RoleManager<IdentityRole>>();
    var mapper = sp.GetRequiredService<IMapper>();
    var jwtOptions = sp.GetRequiredService<IOptions<JWTClass>>().Value;
    return new AuthService(userManager, roleManager, mapper, jwtOptions);
});

// ---------------- JWT Authentication ----------------
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false; // ⚠️ Turn true in production with HTTPS
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        ValidIssuer = configuration["JWT:Issuer"],
        ValidAudience = configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(configuration["JWT:Key"] ?? "SecretKey"))
    };
});

// ---------------- Authorization Policies ----------------
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("StudentOnly", policy => policy.RequireRole("Student"));
});

// ---------------- Controllers ----------------
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// ---------------- API Versioning ----------------
builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
    options.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("x-api-version")
    );
});

// ---------------- Swagger ----------------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    for (var v = 1; v <= 3; v++)
    {
        options.SwaggerDoc($"v{v}", new OpenApiInfo
        {
            Title = "ByWay_APP API",
            Version = $"v{v}",
            Description = $"API documentation for version {v}.0"
        });
    }

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid token."
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// ---------------- Middleware ----------------
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// ✅ Swagger first (before auth)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ByWay_APP API v1");
    c.SwaggerEndpoint("/swagger/v2/swagger.json", "ByWay_APP API v2");
    c.SwaggerEndpoint("/swagger/v3/swagger.json", "ByWay_APP API v3");
    c.RoutePrefix = "swagger";
});

app.UseHttpsRedirection();

// Ensure Uploads folder exists
var uploadsPath = Path.Combine(app.Environment.WebRootPath ?? app.Environment.ContentRootPath, "Uploads");
if (!Directory.Exists(uploadsPath))
    Directory.CreateDirectory(uploadsPath);

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(uploadsPath),
    RequestPath = "/files"
});

app.UseCors("AllowReactApp");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// ✅ Root message
app.MapGet("/", () => Results.Ok("✅ ByWay API is running successfully!"));

app.Run();
