using System.Threading.Tasks;

namespace Veam.Services
{
    public interface IEmailService
    {
        Task SendEmailBySendGridAsync(string apiKey, string fromEmail, string fromFullName, string subject, string message, string email);
        Task SendEmailByGmailAsync(string fromEmail, string fromFullName, string subject, string messageBody, string toEmail, 
            string toFullName, string smtpUser, string smtpPassword, string smtpHost, int smtpPort, bool smtpSSL);
    }
}
