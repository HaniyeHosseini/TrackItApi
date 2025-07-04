using TrackApi.Application.Contracts.Commands;
using TrackApi.Infrastructure.Context;
using TrackApi.Infrastructure.Repositories.Base.Commands;
using TrackItApi.Domain.Models;

namespace TrackApi.Infrastructure.Repositories.Users.Commands
{
    public class UserCommandRepository : BaseCommandRepository<User>, IUserCommandRepository
    {
        public UserCommandRepository(TrackApiContext context) : base(context)
        {
        }
    }
}
