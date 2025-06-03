using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TrackApi.Application.DTOs.User;
using TrackApi.Application.Services.Users;
using TrackApi.Infrastructure.JWT;
using TrackItApi.Common;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserService _userService;
        public AuthController(IJwtTokenGenerator jwtTokenGenerator, IUserService userService)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> Login([FromQuery] string mobile, [FromQuery] string password)
        {
            var user = await _userService.GetUserByMobileAndPassword(mobile, password);
            var token = _jwtTokenGenerator.GenerateToken(user.Mobile, user.Role);
            return Ok(token);
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] InputRegister inputRegister)
        {
            var user = await _userService.Register(inputRegister);
            return Ok(OperationResult<OutputUserDto>.Success(user, HttpStatusCode.OK));
        }
    }
}
