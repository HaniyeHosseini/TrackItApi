using System.Linq.Expressions;
using TrackItApi.Domain.Models;

namespace TrackApi.Infrastructure.Repositories.Base
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(long id);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task<bool> IsAnyExist(Expression<Func<T, bool>> predicate);
    }
}
