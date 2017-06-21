using Pms.Core.Mail;

namespace DemoHarce.CrossCutting.Mail
{
    /// <summary>
    /// Clase que se usa para simular el envío de mail.
    /// </summary>
    public class NoneMailService : IMailService
    {

        public int? SaveMail(string from, string to, string subject, string applicationName, string body, MailPriority mailPriority, int maxRetries)
        {
            return null;
        }
    }
}