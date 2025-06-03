using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackItApi.Domain.Enums;

namespace TrackItApi.Domain.Models
{
    public class User : BaseModel
    {
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string PasswordHash { get; set; }
        public Role Role { get; set; }

        public User(string email, string mobile, string passwordHash, Role role)
        {
            Email = email;
            Mobile = mobile;
            PasswordHash = passwordHash;
            Role = role;
        }
    }
}
