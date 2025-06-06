using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Application.Features.Users.Dtos;

namespace TrackApi.Application.Features.Users.Queries
{
    public class GetUserByMobileAndPasswordQuery : IRequest<OutputUserDto>
    {
        public string Mobile { get; }
        public string Password { get; }

        public GetUserByMobileAndPasswordQuery(string username, string password)
        {
            Mobile = username;
            Password = password;
        }
    }
}
