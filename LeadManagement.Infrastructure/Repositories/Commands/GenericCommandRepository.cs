using LeadManagement.Domain.Interfaces;
using LeadManagement.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LeadManagement.Infrastructure.Repositories.Commands
{
    public class GenericCommandRepository<T> : IGenericCommandRepository<T>
        where T : class, IBaseEntity
    {
        private readonly LeadDbContext _dbContext;
        public DbSet<T> _dbSet => _dbContext.Set<T>();

        public GenericCommandRepository(LeadDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
