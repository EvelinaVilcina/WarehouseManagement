using System.Collections.Generic;
using WarehouseManagement.Models;
using WarehouseManagement.Services;
using Xunit;

namespace WarehouseManagement.Tests
{
    public class ClientManagementSystemTests
    {
        public readonly ClientManagementService _system;

        public ClientManagementSystemTests()
        {
            _system = new ClientManagementService();
        }

        [Fact]
        public void GetClient_WhenAsked_ThenFindsClient()
        {
            Client client = new Client()
            {
                FullName = "a"
            };
            _system.AddNewClient(client);
            Client actualClient = _system.GetClient("a");

            Assert.Equal(client, actualClient);
        }

        [Fact]
        public void GetAllClients_WhenAsked_ThenFindsAllClients()
        {
            Client client = new Client()
            {
                FullName = "a"
            };
            _system.AddNewClient(client);
            
            IList<Client> clientList = _system.GetAllClients();

            Assert.True(clientList.Contains(client));
        }

        [Fact]
        public void AddNewClient_WhenMadeNewClient_ThenSaves()
        {
            Client client = new Client()
            {
                FullName = "a"
            };
            _system.AddNewClient(client);

            Client actualClient = _system.GetClient("a");

            Assert.Equal(client, actualClient);
        }

        [Fact]
        public void RemoveClient_WhenRemoved_ThenTakesClientOutOfTheList()
        {
            Client client = new Client()
            {
                FullName = "a"
            };
            _system.AddNewClient(client);
            _system.RemoveClient("a");

            IList<Client> clientList = _system.GetAllClients();

            Assert.False(clientList.Contains(client));
        }

        [Fact]
        public void ChangeNameOfClient_WhenNeeded_ThenChangesName()
        {
            Client client = new Client()
            {
                FullName = "a"
            };
            _system.AddNewClient(client);
            _system.ChangeNameOfClient("a", "b");

            Assert.Equal("b", client.FullName);  
        }

        [Fact]
        public void ChangeAddressOfClient_WhenNeeded_ThenChangesAddress()
        {
            Client client = new Client()
            {
                FullName = "a"                
            };
            _system.AddNewClient(client);

            Address address = new Address()
            {
                StreetName = "b",                
            };
            _system.ChangeAddressOfClient("a", address);

            Assert.Equal("b", client.Address.StreetName);
        }
    }
}
