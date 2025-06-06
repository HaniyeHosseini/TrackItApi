using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Application.Features.Users.Dtos;

namespace TrackApi.Application.Features.Users.Commands
{
    public class RegisterUserCommand : IRequest<OutputUserDto>
    {
        public InputRegisterUser InputRegisterUser { get;  }

        public RegisterUserCommand(InputRegisterUser inputRegisterUser)
        {
            InputRegisterUser = inputRegisterUser;
        }
    }
}
