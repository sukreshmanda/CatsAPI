using Microsoft.AspNetCore.Authentication.Cookies;

namespace CatsAPI;

public static class AuthenticationExtensions
{
    public static void AddCookieAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
    }
}