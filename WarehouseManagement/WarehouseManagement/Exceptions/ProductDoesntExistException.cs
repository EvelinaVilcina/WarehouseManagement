using System;

namespace WarehouseManagement.Exeptions
{
    public class ProductDoesntExistException : Exception
    {
        public ProductDoesntExistException()
        {
        }

        public ProductDoesntExistException(string messege)
            : base(messege)
        {
        }

        public ProductDoesntExistException(string messege, Exception inner)
            : base(messege, inner)
        {
        }
    }
}
