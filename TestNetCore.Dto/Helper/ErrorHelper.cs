using System;
using System.Collections.Generic;
using System.Text;
using TestNetCore.Core.Model.Enum;
using TestNetCore.Core.Model.Exception;

namespace TestNetCore.Core.Helper
{
    public static class ErrorHelper
    {
        public static Error GetError()
        {
            Error error = new Error()
            {
                Code = Errors.ERROR_UNEXPECTED.ToString(),
                Description = EnumHelper.GetDescription(Errors.ERROR_UNEXPECTED)
            };

            return error;
        }
    }
}
