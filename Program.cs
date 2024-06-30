using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
    // .AddCookie(opt => {
    //     opt.ExpireTimeSpan = TimeSpan.FromSeconds(60);
    //     opt.Cookie.Name = "CatAPICookie";
    //     opt.LoginPath = "/Cats/Login";
    // });

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();
app.UseCookiePolicy(new CookiePolicyOptions{
    MinimumSameSitePolicy = SameSiteMode.Strict,
});

app.Run();


