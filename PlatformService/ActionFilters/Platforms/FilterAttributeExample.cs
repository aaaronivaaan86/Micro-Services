using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace PlatformService.ActionFilters.Platforms
{
    public class FilterAttributeExample : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("AFTER REQUEST");

            Console.WriteLine("FilterAttributeExample First Step");

            Console.WriteLine("FilterAttributeExample Second Step");


        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

            Console.WriteLine("BEFORE REQUEST");
            Console.WriteLine("FilterAttributeExample First Step");

            Console.WriteLine("FilterAttributeExample Second Step");
        }
    }
}
