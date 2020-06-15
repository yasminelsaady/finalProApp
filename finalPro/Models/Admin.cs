using System;
using System.Collections.Generic;

namespace finalPro.Models
{
    public partial class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string NationalId { get; set; }
        public string Email { get; set; }
    }
}
