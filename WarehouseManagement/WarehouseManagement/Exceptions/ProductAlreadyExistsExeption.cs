using System;

namespace WarehouseManagement.Exeptions
{
    public class ProductAlreadyExistsExeption : Exception
    {
        public ProductAlreadyExistsExeption()
        {
        }

        public ProductAlreadyExistsExeption(string messege)
            : base(messege)
        {
        }

        public ProductAlreadyExistsExeption(string messege, Exception inner)
            : base(messege, inner)
        {
        }
    }
}
