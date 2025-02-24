namespace LeadManagement.Domain.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(string recipient, string subject, string body);
    }
}
