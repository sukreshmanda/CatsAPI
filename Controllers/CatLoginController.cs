using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace CatsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CatLoginController : ControllerBase
{
    [HttpPost]
    [Route("/login")]
    public async Task<IActionResult> LoginV1(LoginCredentialsV1 loginCredentials)
    {
        Console.WriteLine("User attempted to Login");
        var role = loginCredentials.UserName.StartsWith("US_") ? "Admin" : "General";
        var claims = new List<Claim>
        {
            new("Name", loginCredentials.UserName),
            new("Role", role)
        };

        ClaimsIdentity claimsIdentity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        await Request.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties { });

        return NoContent();
    }

}

public class LoginCredentialsV1
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }