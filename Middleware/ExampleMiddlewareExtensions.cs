using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middleware
{
    public static class ExampleMiddlewareExtensions
    {
        public static IApplicationBuilder UseCalendarMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CalendarHandlerMiddleware>();
        }

        public static IApplicationBuilder UseMiddlewareModuleExample(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareModuleExample>();
        }
    }
}
