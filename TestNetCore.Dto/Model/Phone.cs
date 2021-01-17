using System;
using System.Collections.Generic;
using System.Text;

namespace TestNetCore.Core.Model
{
    public class Phone
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public virtual User Users { get; set; }
    }
}
