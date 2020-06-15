using System;
using System.Collections.Generic;

namespace finalPro.Models
{
    public partial class User
    {
        public User()
        {
            Logs = new HashSet<Logs>();
            Requist = new HashSet<Requist>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string NationalId { get; set; }
        public string Address { get; set; }
        public int OrgId { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public int? NReq { get; set; }

        public virtual ICollection<Logs> Logs { get; set; }
        public virtual ICollection<Requist> Requist { get; set; }
    }
}
