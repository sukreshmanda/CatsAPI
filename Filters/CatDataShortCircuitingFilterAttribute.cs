using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CatsAPI.Filters;

public class CatDataShortCircuitingFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if(context.ActionArguments.TryGetValue("name", out object? value)){
            string catName = (string)(value ?? "");
            if(catName.StartsWith("US_")){
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }
    }

}