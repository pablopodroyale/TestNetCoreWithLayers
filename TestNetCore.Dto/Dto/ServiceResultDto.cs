using System;
using System.Collections.Generic;
using System.Text;
using TestNetCore.Core.Model.Exception;

namespace TestNetCore.Core.Dto
{
    public class ServiceResultDto<T>
    {
        public bool Succedded { get; set; }

        public List<Error> Errors { get; set; }

        public T obj { get; set; }
    }
}
