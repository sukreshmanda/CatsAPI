using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CatsAPI.Filters;

public class ExceptionHandlingFilterAttribute : ExceptionFilterAttribute, IExceptionFilter
{
    public override void OnException(ExceptionContext context)
    {
        Console.WriteLine($"Exception occured");
        
        context.Result = new ObjectResult("Cat is not present")
        {
            StatusCode = StatusCodes.Status404NotFound,
        };
        context.ExceptionHandled = true;
    }
}