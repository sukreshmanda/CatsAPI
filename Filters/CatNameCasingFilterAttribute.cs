using Microsoft.AspNetCore.Mvc.Filters;

namespace CatsAPI.Filters;

public class CatNameCasingFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ActionArguments.TryGetValue("name", out object? value))
        {
            string catName = (string)(value ?? "");
            context.ActionArguments["name"] = catName.ToUpper();
        }
    }
}