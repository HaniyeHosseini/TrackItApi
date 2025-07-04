using MediatR;
using TrackApi.Application.Contracts.Queries;
using TrackApi.Application.Exceptions;
using TrackApi.Application.Features.Users.Dtos;
using TrackItApi.Domain.Enums;

namespace TrackApi.Application.Features.Users.Queries
{
    public class GetUserByMobileAndPasswordQueryHandler : IRequestHandler<GetUserByMobileAndPasswordQuery, OutputUserDto>
    {
        private readonly IUserQueryRepository _userQueryRepository;

        public GetUserByMobileAndPasswordQueryHandler(IUserQueryRepository userQueryRepository)
        {
            _userQueryRepository = userQueryRepository;
        }

        public async Task<OutputUserDto> Handle(GetUserByMobileAndPasswordQuery request, CancellationToken cancellationToken)
        {
            var user = await _userQueryRepository.GetUserByMobileAndPassword(request.Mobile, request.Password);
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
    }
}
