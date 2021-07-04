using System.Collections.Generic;
using WarehouseManagement.Models;

namespace WarehouseManagement.Interfaces
{
    public interface IClientManagementSystem
    {
        Client GetClient(string FullName);

        IList<Client> GetAllClients();

        void AddNewClient(Client client);

        void RemoveClient(string FullName);

        void ChangeNameOfClient(string FullName, string newFullName);

        void ChangeAddressOfClient(string FullName, Address address);       
    }
}