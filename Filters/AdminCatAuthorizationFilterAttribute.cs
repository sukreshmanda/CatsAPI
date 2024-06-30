using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CatsAPI.Filters;

public class AdminCatAuthorizationFilterAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        List<Claim> claims = context.HttpContext.User.Claims.ToList();
        foreach (var item in claims)
        {
            Console.WriteLine("Claim: "+item.Type +"::"+item.Value);
        }

        Claim? claim = claims.Find(x => x.Type == "Role");
        if (claim == null || claim.Value != "Admin"){
            context.Result = new UnauthorizedResult();
        }
    }
}