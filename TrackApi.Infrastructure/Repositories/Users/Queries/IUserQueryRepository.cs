using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Infrastructure.Repositories.Base.Queries;
using TrackItApi.Domain.Models;

namespace TrackApi.Infrastructure.Repositories.Users.Queries
{
    public interface IUserQueryRepository : IBaseQueryRepository<User>
    {
        Task<User> GetUserByMobileAndPassword(string mobile, string password);
    }
}
