using DO1.Models.Resources;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DO1.Filters
{
    public class LocationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Department dept = (Department)context.ActionArguments["Dept"];

            if (dept.Location != "EG" && dept.Location != "USA")
            {
                context.Result = new BadRequestObjectResult("Department can only be ( EG | USA )");
            }
        }
    }
}
