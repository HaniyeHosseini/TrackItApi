using Microsoft.EntityFrameworkCore;
using TrackApi.Infrastructure.Context;
using TrackApi.Infrastructure.Repositories.Base;
using TrackItApi.Domain.Models;

namespace TrackApi.Infrastructure.Repositories.Users
{
    public class UserRepository(TrackApiContext context) : BaseRepository<User>(context), IUserRepository
    {
        public async Task<User> GetUserByMobileAndPassword(string mobile, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Mobile == mobile && x.PasswordHash == password);
        }
    }
}
