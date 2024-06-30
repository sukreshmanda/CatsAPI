using Microsoft.AspNetCore.Mvc.Filters;

namespace CatsAPI.Filters;

public class CatNameCasingFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine("Cats resource is being called");
        if (context.ActionArguments.TryGetValue("name", out object? value))
        {
            string catName = (string)(value ?? "");
            context.ActionArguments["name"] = catName.ToUpper();
        }
    }
    public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
    {
        Console.WriteLine("Cats resource call is completed");
    }
}