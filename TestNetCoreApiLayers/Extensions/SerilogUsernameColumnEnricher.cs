using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestNetCore.Api.Extensions
{
    public class SerilogUsernameColumnEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory pf)
        {
            var role = "pepe";
            logEvent.AddOrUpdateProperty(pf.CreateProperty("UserName", role));
        }
    }
}
