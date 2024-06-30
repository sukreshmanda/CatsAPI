using CatsAPI.Data;
using CatsAPI.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CatsController : ControllerBase
{

    [HttpGet]
    public List<Cat> GetAll()
    {
        return GetCats;
    }

    [HttpGet("/{name}")]
    public Cat GetById(string name)
    {
        return GetCats.First( a => a.Name == name);
    }









    private static List<Cat> GetCats = [
            new Cat
            {
                Name = "ROSY",
                Breed = "Bombay Cat",
                Owner = "Sofia",
                Url = "https://shorturl.at/WLtlr"
            },
            new Cat
            {
                Name = "LUNA",
                Breed = "American Bobtail",
                Owner = "Nancy",
                Url = "https://shorturl.at/RFkVy"
            },
            new Cat
            {
                Name = "BELLA",
                Breed = "Abyssinian",
                Owner = "Kyla",
                Url = "https://shorturl.at/7yDeP"
            },
        ];
}