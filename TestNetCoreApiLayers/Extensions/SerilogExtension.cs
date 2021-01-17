using Microsoft.AspNetCore.Http;
using Serilog.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestNetCore.Api.Extensions
{
    public class SerilogExtension
    {
        private readonly RequestDelegate next;

        public SerilogExtension(RequestDelegate next)
        {
            this.next = next;
        }

        public Task Invoke(HttpContext context)
        {
            LogContext.PushProperty("UserName", context.User.Identity.Name != null ? context.User.Identity.Name : "anonimo");

            return next(context);
        }
    }
}
