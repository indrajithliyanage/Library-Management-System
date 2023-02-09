using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace LibraryManagementSystem.EmailService
{
    public class SendGridMailService : IMailService
    {
        private EMailSettings _mailSettings;

        public SendGridMailService(EMailSettings mailSettings)
        {
            _mailSettings = mailSettings;
        }

        public async Task<Response> SendMailAsync(string toEmail, string ccEmail, string subject, string content)
        {
            Response result;

            try
            {
                var client = new SendGridClient(_mailSettings.APIKey);
                var from = new EmailAddress(_mailSettings.FromMailId, _mailSettings.FromMailName);
                var to = new EmailAddress(toEmail);
                var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
                msg.AddCc(ccEmail);
                result = await client.SendEmailAsync(msg);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }
    }
}