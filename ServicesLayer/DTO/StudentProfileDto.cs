using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByWay.ServicesLayer.DTO
{
    public class StudentProfileDto
    {
        public string Country { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;

        public string CardName { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
        public string CVC { get; set; } = string.Empty;
    }

}
