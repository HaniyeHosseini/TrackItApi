using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackItApi.Domain.Enums;

namespace TrackApi.Application.Features.Users.Dtos
{
    public class OutputUserDto
    {
        public long Id { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public string RoleName { get; set; }

    }
}
