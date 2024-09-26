using Microsoft.AspNetCore.Mvc;

namespace CatsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SecondaryController : BaseController
{
    [HttpPost]
    [Route("/login")]
    public void LoginV2(MessageRequest loginCredentials)
    {
        return;
    }

    [HttpPost("/logoutv2")]
    public void LogoutV2(MessageRequest logout)
    {
        return;
    }

    [HttpPost("/logoutv3/{id}")]
    public void LogoutWithParamV3(int id, MessageRequest logoutNo)
    {
        return;
    }

    public class MessageRequest{
        public string? Name { get; set; }
        public long? Id { get; set; }
    }
}