using System.Linq.Expressions;
using TrackItApi.Domain.Models;

namespace TrackApi.Application.Contracts.Queries
{
    public interface IBaseQueryRepository<T> where T : BaseModel
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<bool> IsAnyExist(Expression<Func<T, bool>> predicate);
    }
}

