using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Infrastructure.Repositories.Base;
using TrackItApi.Domain.Models;

namespace TrackApi.Infrastructure.Repositories.Users
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserByMobileAndPassword(string mobile, string password);
        
    }
}
