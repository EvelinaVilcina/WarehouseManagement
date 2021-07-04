using System.Collections.Generic;
using System.Linq;
using WarehouseManagement.Exeptions;
using WarehouseManagement.Interfaces;
using WarehouseManagement.Models;

namespace WarehouseManagement.Services
{
    public class ClientManagementService : IClientManagementSystem
    {
        public readonly List<Client> _clients;

        public ClientManagementService()
        {
            _clients = new List<Client>();
        }

        public Client GetClient(string FullName)
        {
            Client client = _clients.SingleOrDefault(c => c.FullName == FullName);

            if (client == null)
            {
                throw new ClientDoesnotExsistException("No Client faund with this name");
            }

            return client;
        }
        
        public IList<Client> GetAllClients()
        {
            return _clients.ToList();
        }

        public void AddNewClient(Client client)
        {
            _clients.Add(client);
        }

        public void RemoveClient(string FullName)
        {
            Client client = _clients.SingleOrDefault(c => c.FullName == FullName);
            _clients.Remove(client);
        }

        public void ChangeNameOfClient(string FullName, string newFullName)
        {
            Client client = _clients.SingleOrDefault(c => c.FullName == FullName);
            client.FullName = newFullName;
        }

        public void ChangeAddressOfClient(string FullName, Address address)
        {
            Client client = _clients.SingleOrDefault(c => c.FullName == FullName);
            client.Address = address;
        }
    }
}
