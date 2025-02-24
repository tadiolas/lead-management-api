using LeadManagement.Domain.Entities;
using MediatR;

namespace LeadManagement.Application.Commands.Leads.Update
{
    public class UpdateLeadRequest : IRequest
    {
        public Lead Lead { get; set; }

        public UpdateLeadRequest(Lead lead)
        {
            Lead = lead;
        }
    }
}
