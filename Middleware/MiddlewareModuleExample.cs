using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middleware
{
    public class MiddlewareModuleExample
    {
        private RequestDelegate _next;

        public MiddlewareModuleExample(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("<h1><font color=red>MiddlewareModuleExample: Beginning of Request</font></h1><hr>");
            //await _next.Invoke(context);
            await context.Response.WriteAsync("<hr><h1><font color=red>MiddlewareModuleExample: End of Request</font></h1>");            
        }
    }
}
