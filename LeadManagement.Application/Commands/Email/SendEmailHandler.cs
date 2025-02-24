using LeadManagement.Domain.Interfaces;
using MediatR;

namespace LeadManagement.Application.Commands.Email
{
    public class SendEmailHandler : IRequestHandler<SendEmailRequest, bool>
    {
        private readonly IEmailService _emailService;

        public SendEmailHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task<bool> Handle(SendEmailRequest request, CancellationToken cancellationToken)
        {
            var isSent = await _emailService.SendEmailAsync(request.Recipient, request.Subject, request.Body);

            return isSent;
        }
    }
}
