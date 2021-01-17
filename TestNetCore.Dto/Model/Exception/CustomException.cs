using System;
using System.Collections.Generic;
using System.Text;
using TestNetCore.Core.Dto;

namespace TestNetCore.Core.Model.Exception
{
    public class CustomException : System.Exception
    {
        public IEnumerable<Error> Errors { get; set; }

        public CustomException()
        {
            Errors = new List<Error>();
        }

        public CustomException(IEnumerable<Error> errors)
        {
            this.Errors = errors;
        }
    }
}
