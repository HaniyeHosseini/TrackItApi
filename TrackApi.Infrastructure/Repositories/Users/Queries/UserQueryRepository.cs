using Microsoft.EntityFrameworkCore;
using TrackApi.Infrastructure.Context;
using TrackApi.Infrastructure.Repositories.Base.Queries;
using TrackItApi.Domain.Models;

namespace TrackApi.Infrastructure.Repositories.Users.Queries
{
    public class UserQueryRepository : BaseQueryRepository<User>, IUserQueryRepository
    {
        public UserQueryRepository(TrackApiContext context) : base(context)
        {
        }
        public async Task<User> GetUserByMobileAndPassword(string mobile, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Mobile == mobile && x.PasswordHash == password);
        }
    }
}
