using MediatR;
using TrackApi.Application.Contracts.Commands;
using TrackApi.Application.Features.Users.Dtos;
using TrackItApi.Domain.Enums;
using TrackItApi.Domain.Models;

namespace TrackApi.Application.Features.Users.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, OutputUserDto>
    {
        private readonly IUserCommandRepository _userCommandRepository;

        public RegisterUserCommandHandler(IUserCommandRepository userCommandRepository)
        {
            _userCommandRepository = userCommandRepository;
        }

        public async Task<OutputUserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var inputRegister = request.InputRegisterUser;
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(inputRegister.Password);
            var user = new User(inputRegister.Email, inputRegister.Mobile, inputRegister.Password, Role.User);
            await _userCommandRepository.AddAsync(user);
            return new OutputUserDto()
            {
                Id = user.Id,
                Email = user.Email,
                Mobile = user.Mobile,
                Role = user.Role,
                RoleName = Enum.GetName<Role>(user.Role)
            };
        }
    }
}
