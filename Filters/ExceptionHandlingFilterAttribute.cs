using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CatsAPI.Filters;

public class ExceptionHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        context.Result = new ObjectResult("Cat is not present")
        {
            StatusCode = StatusCodes.Status404NotFound,
        };
        context.ExceptionHandled = true;
    }
}