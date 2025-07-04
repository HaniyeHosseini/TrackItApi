using Microsoft.EntityFrameworkCore;
using TrackApi.Application.Contracts.Commands;
using TrackApi.Infrastructure.Context;
using TrackItApi.Domain.Models;

namespace TrackApi.Infrastructure.Repositories.Base.Commands
{
    public class BaseCommandRepository<T> : IBaseCommandRepository<T> where T : BaseModel
    {
        protected readonly TrackApiContext _context;
        private readonly DbSet<T> _dbSet;
        public BaseCommandRepository(TrackApiContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(long id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            if (entities == null || !entities.Any()) throw new ArgumentNullException(nameof(entities));
            await _dbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }
    }
}

