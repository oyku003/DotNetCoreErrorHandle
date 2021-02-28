using System;
using System.Collections.Generic;

namespace UdemySwagger2.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Addresses = new HashSet<Addresses>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime? BirthDay { get; set; }
        public int Gender { get; set; }

        public virtual ICollection<Addresses> Addresses { get; set; }
    }
}
