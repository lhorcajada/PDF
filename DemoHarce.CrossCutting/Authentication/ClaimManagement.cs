using DemoHarce.CrossCutting.Helpers;
using System.Linq;
using System.Security;
using System.Security.Claims;
using System.Security.Principal;

namespace DemoHarce.CrossCutting.Authentication
{
    /// <summary>
    /// Clase que maneja los Claims del token recibidos del STS de ADFS.
    /// </summary>
    public class ClaimManagement : IClaimManagement
    {
        private readonly IPrincipal _principal;
        public ClaimManagement(IPrincipal principal)
        {
            _principal = principal;
        }
        /// <summary>
        /// Obtiene el login del usuario que hace la petición.
        /// </summary>
        /// <returns></returns>
        public string GetLogin()
        {
            var identity = (ClaimsPrincipal)_principal;
            Throw<SecurityException>.WhenObject.IsNull(() => identity);
            var domain = identity.Claims.FirstOrDefault(c => c.Type == Extensions.CustomClaimTypes.Domain);
            var name = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.WindowsAccountName);
            Throw<SecurityException>.WhenObject.IsNull(() => domain);
            Throw<SecurityException>.WhenObject.IsNull(() => name);
            var login = $@"{domain.Value}\{name.Value}";
            return login;
        }
    }

}
