using System;
using System.Collections.Generic;

namespace finalPro.Models
{
    public partial class Requist
    {
        public int Id { get; set; }
        public int OrgId { get; set; }
        public decimal Lat { get; set; }
        public decimal Long { get; set; }
        public byte[] DateTime { get; set; }
        public bool? Response { get; set; }
        public int CitId { get; set; }
        public int? UserId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public byte[] Photo { get; set; }

        public virtual Citizen Cit { get; set; }
        public virtual Organization Org { get; set; }
        public virtual User User { get; set; }
    }
}
