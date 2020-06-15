using System;
using System.Collections.Generic;

namespace finalPro.Models
{
    public partial class Organization
    {
        public Organization()
        {
            Requist = new HashSet<Requist>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Lat { get; set; }
        public decimal Long { get; set; }

        public virtual ICollection<Requist> Requist { get; set; }
    }
}
