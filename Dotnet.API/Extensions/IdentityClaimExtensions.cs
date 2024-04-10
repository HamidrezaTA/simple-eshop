using System.Net;
using Dotnet.API.Exceptions;

namespace Dotnet.API.Extensions
{
    public static class IdentityClaimExtensions
    {
        public static string GetMobileNumberClaim(this System.Security.Claims.ClaimsPrincipal claimsPrincipal)
        {
            var mobileNumberClaim = claimsPrincipal.Claims.FirstOrDefault(clms => clms.Type == "MobileNumber");
            if (mobileNumberClaim == null)
                throw new CustomException((int)HttpStatusCode.Forbidden, "Token is not valid and does not cotain mobile number claim");

            return mobileNumberClaim.Value;
        }
    }
}