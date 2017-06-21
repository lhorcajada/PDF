using Pms.Core.Mail;
using System;
using System.Net.Mail;
using MailPriority = Pms.Core.Mail.MailPriority;

namespace DemoHarce.CrossCutting.Mail
{
    /// <summary>
    /// Clase con la que se podrán realizar todas las acciones de envíos de mail.
    /// </summary>
    public class MailService : IMailService
    {       

        /// <summary>
        /// Guarda un mail en MAILDB
        /// </summary>
        /// <param name="from">Quien envía el correo</param>
        /// <param name="to">A quien o quienes lo envia. (emails separados por comas)</param>
        /// <param name="subject">Título del mensaje</param>
        /// <param name="applicationName">Nombre de la aplicación</param>
        /// <param name="body">Contenido del mensaje</param>
        /// <param name="mailPriority">Prioridad de envío</param>
        /// <param name="maxRetries">Número de reintentos para enviar</param>
        public int? SaveMail(string from, string to, string subject, string applicationName, string body, MailPriority mailPriority, int maxRetries)
        {
            var message = new MailMessage(from, to, subject, body);
            message.IsBodyHtml = true;

            int? Id = MailManager.Send(message, applicationName, DateTime.Now, mailPriority, maxRetries);
            message.Dispose();
            return Id;
        }
    }
}
