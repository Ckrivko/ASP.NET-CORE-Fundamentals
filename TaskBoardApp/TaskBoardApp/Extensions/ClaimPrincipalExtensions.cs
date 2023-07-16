using System.Security.Claims;

namespace TaskBoardApp.Extentions
{
    public  static class ClaimPrincipalExtensions
    {
        public static string GetId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

    }
}
