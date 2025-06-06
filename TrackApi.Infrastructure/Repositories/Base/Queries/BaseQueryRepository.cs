using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TrackApi.Infrastructure.Context;
using TrackItApi.Domain.Models;

namespace TrackApi.Infrastructure.Repositories.Base.Queries
{
    public class BaseQueryRepository<T> : IBaseQueryRepository<T> where T : BaseModel
    {
        protected readonly TrackApiContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseQueryRepository(TrackApiContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }
        public async Task<bool> IsAnyExist(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }
    }
}

