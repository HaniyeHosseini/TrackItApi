using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackItApi.Domain.Models;

namespace TrackApi.Application.Contracts.Commands
{
    public interface IBaseCommandRepository<T> where T : BaseModel
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(long id);
        Task AddRangeAsync(IEnumerable<T> entities);
    }
}

