using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManagement.Exeptions
{
    public class OrderAlreadyEmptyExeption : Exception
    {
        public OrderAlreadyEmptyExeption()
        {
        }

        public OrderAlreadyEmptyExeption(string messege)
            : base(messege)
        {
        }

        public OrderAlreadyEmptyExeption(string messege, Exception inner)
            : base(messege, inner)
        {
        }
    }
}
