using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackItApi.Domain.Enums;
using TrackItApi.Domain.Models;

namespace TrackApi.Infrastructure.JWT
{
    public interface IJwtTokenGenerator
    {
        public string GenerateToken(string mobile, Role role);
    }
}
