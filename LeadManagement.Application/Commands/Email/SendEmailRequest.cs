using MediatR;

namespace LeadManagement.Application.Commands.Email
{
    public class SendEmailRequest : IRequest<bool>
    {
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public SendEmailRequest(string recipient, string subject, string body)
        {
            Recipient = recipient;
            Subject = subject;
            Body = body;
        }
    }
}
