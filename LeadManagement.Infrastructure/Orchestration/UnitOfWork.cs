using LeadManagement.Domain.Interfaces;
using LeadManagement.Infrastructure.Context;

namespace LeadManagement.Infrastructure.Orchestration
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LeadDbContext _dbContext;
        public UnitOfWork(LeadDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
