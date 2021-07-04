using System;
using System.Collections.Generic;

namespace WarehouseManagement.Models
{
    public class Order
    {
        public string OrderNumber { get; set; }

        public DateTime DateTime { get; set; }

        public Client Client { get; set; }

        public List<Product> Products { get; set; }
    }
}

