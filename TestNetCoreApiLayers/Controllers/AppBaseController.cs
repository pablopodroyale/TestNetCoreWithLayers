using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestNetCore.Api.Extensions;

namespace TestNetCore.Api.Controllers
{
    public class AppBaseController : Controller
    {
        private readonly IOptions<ApplicationSettings> _options;
        public AppBaseController(IOptions<ApplicationSettings> options)
        {
            this._options = options;
        }
    }
}
