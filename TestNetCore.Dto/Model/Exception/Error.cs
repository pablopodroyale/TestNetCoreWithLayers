using EnumsNET;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using TestNetCore.Core.Helper;
using TestNetCore.Core.Model.Enum;

namespace TestNetCore.Core.Model.Exception
{
    public class Error
    {

        public Error(Errors error)
        {
            this.Code = error.ToString();
            this.Description = error.GetDescription();
        }

        public Error()
        {

        }

        public string Code { get; set; }
        public string Description { get; set; }
    }
}
