using LeadManagement.Domain.Interfaces;

namespace LeadManagement.Infrastructure.Services
{
    public class FakeEmailService : IEmailService
    {
        public Task<bool> SendEmailAsync(string recipient, string subject, string body)
        {
            Console.WriteLine();
            Console.WriteLine("############");
            Console.WriteLine($"Sending email to {recipient}");
            Console.WriteLine($"subject: {subject}");
            Console.WriteLine($"body: {body}");
            Console.WriteLine("############");
            Console.WriteLine();

            return Task.FromResult(true);
        }
    }
}
