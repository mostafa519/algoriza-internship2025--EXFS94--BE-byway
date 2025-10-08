using AutoMapper;
using ByWay.DomainLayer.Model;
using ByWay.DomainLayer.ModelAuth;
using ByWay.RepositoryLayer.Helper;
using ByWay.ServicesLayer.DTO;
using ByWay.ServicesLayer.Service.Contact_Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ByWay.ServicesLayer.Service.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<Student> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly JWTClass _jwtOptions;

        public AuthService(UserManager<Student> userManager,
            RoleManager<IdentityRole> roleManager,
            IMapper mapper,
            JWTClass jwtOptions)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _jwtOptions = jwtOptions;
        }

        public async Task<AuthModel> RegisterAsync(StudentRegisterDto model, string role = "Student")
        {
            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
                return new AuthModel { Message = "User already exists!" };

            var user = _mapper.Map<Student>(model);
            user.EmailConfirmed = true;

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return new AuthModel { Message = string.Join(", ", result.Errors.Select(e => e.Description)) };

            if (!await _roleManager.RoleExistsAsync(role))
                await _roleManager.CreateAsync(new IdentityRole(role));

            await _userManager.AddToRoleAsync(user, role);

            return await GenerateJwtToken(user, role);
        }

        public async Task<AuthModel> UserLoginAsync(StudentLoginDto model, string role = "Student")
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
                return new AuthModel { Message = "Invalid credentials!" };

            return await GenerateJwtToken(user, role);
        }

        public async Task<AuthModel> AdminLoginAsync(StudentLoginDto model)
        {
            return await UserLoginAsync(model, "Admin");
        }

        public async Task<AuthModel> GenerateJwtToken(Student user, string role = "")
        {
            var rolesList = await _userManager.GetRolesAsync(user);

            if (!string.IsNullOrEmpty(role) && !rolesList.Contains(role))
                return new AuthModel { Message = $"User does not have role '{role}'" };

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName ?? ""),
                new Claim(ClaimTypes.Email, user.Email ?? "")
            };
            claims.AddRange(rolesList.Select(r => new Claim(ClaimTypes.Role, r)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwtOptions.DurationInDays),
                signingCredentials: creds
            );

            return new AuthModel
            {
                IsAuthenticated = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresOn = token.ValidTo,
                Username = user.UserName,
                Email = user.Email,
                Roles = rolesList.ToList()
            };
        }

        public async Task<List<StudentDto>> GetAllStudentsAsync()
        {
            var students = await _userManager.Users.Include(u => u.Profile).ToListAsync();
            return _mapper.Map<List<StudentDto>>(students);
        }
    }
}
