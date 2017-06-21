using DemoHarce.CrossCutting.Resources;

namespace DemoHarce.CrossCutting.Mail
{
    /// <summary>
    /// Clase que crear el servicio de Mail
    /// </summary>
    public static class MailFactory
    {

        /// <summary>
        /// Crea un objeto que implementa la interfaz IMailService. Si el parámetro isMailEnabled es false
        /// crea un objeto NoneMailService que simula el servicio de mail.
        /// </summary>
        /// <param name="isMailEnabled"></param>
        /// <returns></returns>
        public static IMailService Create(bool isMailEnabled = true)
        {
            if (Settings.Default.MailEnabled && isMailEnabled)
            {
                return new MailService();
            }
            return new NoneMailService();
        }
    }
}
