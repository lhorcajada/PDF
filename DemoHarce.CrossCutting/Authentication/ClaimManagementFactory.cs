using DemoHarce.CrossCutting.Resources;
using System.Linq;
using System.Security.Claims;
using System.Threading;

namespace DemoHarce.CrossCutting.Authentication
{
    /// <summary>
    /// Factoría que devuelve un objeto que maneja claims
    /// </summary>
    public static class ClaimManagementFactory
    {

        /// <summary>
        /// Devuelve un objeto ClaimManagement. El parámetro claimsEnabled a false 
        /// hace que el método devuelva un objeto NoneClaimManagement. 
        /// </summary>
        /// <returns></returns>
        public static IClaimManagement GetClaimManagement(bool claimsEnabled = true)
        {
            if (Settings.Default.ClaimsEnabled && claimsEnabled)
            {
                var claimsPrincipal = (ClaimsPrincipal)Thread.CurrentPrincipal;
                if (claimsPrincipal.Claims.Any(x => x.Type == ClaimTypes.WindowsAccountName)
                    && claimsPrincipal.Claims.Any(x => x.Type == Extensions.CustomClaimTypes.Domain))
                {
                    return new ClaimManagement(claimsPrincipal);
                }
            }
            return new NoneClaimManagement();
        }
    }

}
