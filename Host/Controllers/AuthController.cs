using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TrackApi.Application.Features.Users.Commands;
using TrackApi.Application.Features.Users.Dtos;
using TrackApi.Application.Features.Users.Queries;
using TrackApi.Infrastructure.JWT;
using TrackItApi.Common;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IMediator _mediator;
        public AuthController(IJwtTokenGenerator jwtTokenGenerator, IMediator mediator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Login([FromQuery] string mobile, [FromQuery] string password)
        {
            var user = await _mediator.Send(new GetUserByMobileAndPasswordQuery(mobile, password));
            var token = _jwtTokenGenerator.GenerateToken(user.Mobile, user.Role);
            return Ok(token);
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] InputRegisterUser inputRegister)
        {
            var user = await _mediator.Send(new RegisterUserCommand(inputRegister));
            return Ok(OperationResult<OutputUserDto>.Success(user, HttpStatusCode.OK));
        }
    }
}
