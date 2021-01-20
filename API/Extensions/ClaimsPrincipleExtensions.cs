using System.Security.Claims;

namespace API.Extensions
{
    public static class ClaimsPrincipleExtensions
    {
        public static string GetUserName (this ClaimsPrincipal user){
            // ClaimTypes.Name retrieves from JwtRegisteredClaimNames.NameId
            return user.FindFirst(ClaimTypes.Name)?.Value;
        }
        public static int GetUserId (this ClaimsPrincipal user){
            // ClaimTypes.NameIdentifier retrieves from JwtRegisteredClaimNames.UniqueName
            return int.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }
    }
}