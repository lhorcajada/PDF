using DemoHarce.CrossCutting.Helpers;
using System.Linq;
using System.Security;
using System.Security.Claims;
using System.Threading;

namespace DemoHarce.CrossCutting.Authentication
{
    /// <summary>
    /// Clase que simula el manejo de claims
    /// </summary>
    public class NoneClaimManagement : IClaimManagement
    {
        ClaimsPrincipal _claimsPrincipal;
        public NoneClaimManagement()
        {
            _claimsPrincipal = new ClaimsPrincipal();
            ClaimsIdentity claimsIdentity = new ClaimsIdentity();
            var name = Thread.CurrentPrincipal.Identity.Name.Substring(3);
            claimsIdentity.AddClaim(new Claim(ClaimTypes.WindowsAccountName, name));
            claimsIdentity.AddClaim(new Claim(Extensions.CustomClaimTypes.Domain, "ES"));

            _claimsPrincipal.AddIdentity(claimsIdentity);

        }
        /// <summary>
        /// Devuelve un login de un usuario existente. En este caso el del recurso AppPoolUser.
        /// </summary>
        /// <returns></returns>
        public string GetLogin()
        {
            var domain = _claimsPrincipal.Claims.FirstOrDefault(c => c.Type == Extensions.CustomClaimTypes.Domain);
            var name = _claimsPrincipal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.WindowsAccountName);
            Throw<SecurityException>.WhenObject.IsNull(() => domain);
            Throw<SecurityException>.WhenObject.IsNull(() => name);
            var login = $@"{domain.Value}\{name.Value}";
            return login;
        }
    }
}
