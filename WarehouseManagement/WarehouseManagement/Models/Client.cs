using System;
using System.Collections.Generic;

namespace WarehouseManagement.Models
{
    public class Client 
    {
        public string FullName { get; set; }

        public Address Address { get; set; }

        public List<Product> OrderedProducts { get; set; }
    }
}
