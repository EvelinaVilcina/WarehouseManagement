using System;

namespace WarehouseManagement.Exeptions
{
    public class ClientDoesnotExsistException : Exception
    {
        public ClientDoesnotExsistException()
        {
        }

        public ClientDoesnotExsistException(string messege)
            : base(messege)
        {
        }

        public ClientDoesnotExsistException(string messege, Exception inner)
            : base(messege, inner)
        {
        }
    }
}
