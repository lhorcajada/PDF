
using Pms.Core.Mail;

namespace DemoHarce.CrossCutting.Mail
{
    /// <summary>
    /// Contrato del servicio de Mail
    /// </summary>
    public interface IMailService
    {
        /// <summary>
        /// Guarda un registro en la base de datos de MailDB.
        /// </summary>
        /// <param name="from">Usuario que lo envía</param>
        /// <param name="to">Usuario que lo va a recibir</param>
        /// <param name="subject">Título del mail</param>
        /// <param name="applicationName">Aplicación desde la que se envía el mail</param>
        /// <param name="body">Cuerpo del mail</param>
        /// <param name="mailPriority">Prioridad</param>
        /// <param name="maxRetries">Número máximo de intentos de envío en caso de error</param>
        /// <returns>Devuelve el Id del registro. Nulo significa que no se guardó.</returns>
        int? SaveMail(string from, string to, string subject, string applicationName, string body,
            MailPriority mailPriority, int maxRetries);
    }
}
