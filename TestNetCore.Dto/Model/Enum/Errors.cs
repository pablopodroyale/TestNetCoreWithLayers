using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestNetCore.Core.Model.Enum
{
    public enum Errors
    {
        [Description("Error inesperado")]
        ERROR_UNEXPECTED = 1,
        [Description("Usuario incorrecto")]
        ERROR_USERNAME_INVALID = 2,
        [Description("Password incorrecto")]
        ERROR_PASSWORD_INVALID = 3
    }
}
