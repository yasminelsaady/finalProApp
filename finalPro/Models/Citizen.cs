using System;
using System.Collections.Generic;

namespace finalPro.Models
{
    public partial class Citizen
    {
        public Citizen()
        {
            Requist = new HashSet<Requist>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string NationalId { get; set; }
        public string Password { get; set; }
        public byte[] Photo { get; set; }
        public int? NReq { get; set; }

        public virtual ICollection<Requist> Requist { get; set; }
    }
}
