using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Enums;
using LeadManagement.Domain.Interfaces;
using LeadManagement.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LeadManagement.Infrastructure.Repositories.Queries
{
    public class LeadQueryRepository : ILeadQueryRepository
    {
        private readonly LeadDbContext _dbContext;
        public LeadQueryRepository(LeadDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Lead>> GetLeadsByStatus(StatusLead status)
        {
            if (status == StatusLead.Invited)
            {
                return await _dbContext.Lead
                    .Where(l => l.Status == status)
                    .Include(l => l.Customer)
                    .Join(
                        _dbContext.Category,
                        lead => lead.CategoryId,
                        category => category.Id,
                        (lead, category) => new { lead, category }
                    )
                    .Select(result => new Lead(
                        result.lead,
                        result.lead.Customer,
                        result.category
                    ))
                    .ToListAsync();
            }
            else
            {
                return await _dbContext.Lead
                    .Where(l => l.Status == status)
                    .Include(l => l.Customer)
                        .ThenInclude(c => c.AdditionalContact)
                    .Join(
                        _dbContext.Category,
                        lead => lead.CategoryId,
                        category => category.Id,
                        (lead, category) => new { lead, category }
                    )
                    .Select(result => new Lead(
                        result.lead,
                        result.lead.Customer,
                        result.category,
                        result.lead.Customer.AdditionalContact
                    ))
                    .ToListAsync();
            }
        }
    }
}
