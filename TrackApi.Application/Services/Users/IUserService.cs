using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Application.DTOs.User;
using TrackApi.Application.Exceptions;
using TrackApi.Infrastructure.Repositories.Users;
using TrackItApi.Domain.Enums;
using TrackItApi.Domain.Models;

namespace TrackApi.Application.Services.Users
{
    public interface IUserService
    {
        Task<OutputUserDto> GetUserByMobileAndPassword(string mobile, string password);
        Task<OutputUserDto> Register(InputRegister inputRegister);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OutputUserDto> GetUserByMobileAndPassword(string mobile, string password)
        {
            var user = await _userRepository.GetUserByMobileAndPassword(mobile, password);
            if (user == null)
            {
                throw new RecordNotFoundException();
            }
            return new OutputUserDto()
            {
                Id = user.Id,
                Email = user.Email,
                Mobile = user.Mobile,
                Role = user.Role,
                RoleName = Enum.GetName<Role>(user.Role)
            };
        }

        public async Task<OutputUserDto> Register(InputRegister inputRegister)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(inputRegister.Password);
            var user = new User(inputRegister.Email, inputRegister.Mobile, inputRegister.Password, Role.User);
            await _userRepository.AddAsync(user);
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
