using System;
using System.Collections.Generic;

namespace UdemySwagger2.Models
{
    public partial class Addresses
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Province { get; set; }
        public string PostCode { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customers Customer { get; set; }
    }
}
