using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Enums;

namespace LeadManagement.Domain.Interfaces
{
    public interface ILeadQueryRepository
    {
        Task<IEnumerable<Lead>> GetLeadsByStatus(StatusLead status);
    }
}
