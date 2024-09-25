using Microsoft.AspNetCore.Mvc;

namespace CatsAPI.Controllers;

public class BaseController: ControllerBase
{
    [HttpPost]
    [Route("/login")]
    public void Login([FromBody] MessageRequest loginCredentials)
    {
        return;
    }

    [HttpPost("/logout")]
    public void Logout([FromBody] MessageRequest logout)
    {
        return;
    }

    public class MessageRequest{
        public string? Name { get; set; }
        public long? Id { get; set; }
    }
}