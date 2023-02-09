using SendGrid;
using System.Threading.Tasks;

namespace LibraryManagementSystem.EmailService
{
    public interface IMailService
    {
        Task<Response> SendMailAsync(string toEmail, string ccEmail, string subject, string content);
    }
}
