using LeadManagement.Application.Commands.Email;
using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Interfaces;
using MediatR;

namespace LeadManagement.Application.Commands.Leads.Update
{
    public class UpdateLeadHandler : IRequestHandler<UpdateLeadRequest>
    {
        private readonly IGenericCommandRepository<Lead> _genericRepository;
        private readonly ISender _sender;
        public UpdateLeadHandler(IGenericCommandRepository<Lead> genericRepository, ISender sender)
        {
            _genericRepository = genericRepository;
            _sender = sender;
        }

        public async Task Handle(UpdateLeadRequest request, CancellationToken cancellationToken)
        {
            if (request.Lead.ShouldSendEmail())
            {
                await _sender.Send(new SendEmailRequest("vendas@test.com", "Price above US $ 500", $"Lead with ID {request.Lead.Id} has a price above US $ 500"), cancellationToken);
            }

            await _genericRepository.UpdateAsync(request.Lead);
        }
    }
}
