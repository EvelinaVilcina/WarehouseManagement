using System;
namespace WarehouseManagement.Exeptions
{
    public class OrderDoesntExsistExeption : Exception
    {
        public OrderDoesntExsistExeption()
        {
        }

        public OrderDoesntExsistExeption(string messege)
            : base(messege)
        {
        }

        public OrderDoesntExsistExeption(string messege, Exception inner)
            : base(messege, inner)
        {
        }
    }
}
