using System;
using System.Collections.Generic;
using System.Text;

namespace TestNetCore.Core.Model
{
    public class Logs
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string MessageTemplate { get; set; }
        public string Level { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Exception { get; set; }
        public string Properties { get; set; }
        public string UserName { get; set; }






    }
}
