using LeadManagement.Domain.Entities;
using MediatR;

namespace LeadManagement.Application.Commands.Leads.Update
{
    public class UpdateLeadRequest : IRequest
    {
        public int Id { get; set; }
        public Lead Lead { get; set; }

        public UpdateLeadRequest(int id, Lead lead)
        {
            Id = id;
            Lead = lead;
        }
    }
}
