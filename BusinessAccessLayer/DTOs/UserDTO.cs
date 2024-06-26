using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.DTOs
{
    public class UserDTO
    {
        public int? UserId { get; set; }
        public string UserLogin { get; set; } = string.Empty;
        public string UserPassword { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string UserSurname { get; set; } = string.Empty;
    }
}
