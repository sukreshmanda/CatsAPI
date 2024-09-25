using Microsoft.AspNetCore.Mvc;

namespace CatsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SecondaryController : BaseController
{
    [HttpPost]
    [Route("/login")]
    public void Login([FromBody] MessageRequest loginCredentials)
    {
        return;
    }

    [HttpPost("/logout")]
    public void Logout(MessageRequest logout)
    {
        return;
    }

    public class MessageRequest{
        public string? Name { get; set; }
        public long? Id { get; set; }
    }
}