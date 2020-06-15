using System;
using System.Collections.Generic;

namespace finalPro.Models
{
    public partial class Logs
    {
        public int UserId { get; set; }
        public byte[] DateTime { get; set; }

        public virtual User User { get; set; }
    }
}
