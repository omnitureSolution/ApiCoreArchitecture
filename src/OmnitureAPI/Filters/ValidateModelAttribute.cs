using Omniture.Shared.Validation;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SocietyCareAPI.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
                
            }
        }
    }
}
