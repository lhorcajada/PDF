namespace DemoHarce.CrossCutting.Authentication
{
    /// <summary>
    /// Clase que maneja los Claims del token recibidos del STS de ADFS.
    /// </summary>
    public interface IClaimManagement
    {
        /// <summary>
        /// Obtiene el login del usuario que hace la petición.
        /// </summary>
        /// <returns></returns>
        string GetLogin();

    }
}