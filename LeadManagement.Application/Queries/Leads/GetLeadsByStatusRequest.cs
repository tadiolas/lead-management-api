using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Enums;
using MediatR;

namespace LeadManagement.Application.Queries.Leads
{
    public class GetLeadsByStatusRequest : IRequest<IEnumerable<Lead>>
    {
        public GetLeadsByStatusRequest(StatusLead status)
        {
            Status = status;
        }
        public StatusLead Status { get; set; }
    }
}
