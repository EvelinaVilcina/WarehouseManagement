using System;
using WarehouseManagement.Exeptions;
using WarehouseManagement.Models;
using WarehouseManagement.Services;

namespace WarehouseManagement.Ui
{
    public class ClientManagementController
    {
        private readonly ClientManagementService _clientsManagmentService;
        private readonly CorectUserInputHelper _userInputHelper;

        public ClientManagementController(ClientManagementService clientManagementService, CorectUserInputHelper corectUserInputHelper)
        {
            _clientsManagmentService = clientManagementService;
            _userInputHelper = corectUserInputHelper;
        }

        public void Start()
        {
            Console.WriteLine("Write number of your Client Management Service operation!");
            Console.WriteLine("1 - GetClient");
            Console.WriteLine("2 - GetAllClients");
            Console.WriteLine("3 - AddNewClient");
            Console.WriteLine("4 - RemoveClient");
            Console.WriteLine("5 - ChangeNameOfClient");
            Console.WriteLine("6 - ChangeAddressOfClient");
            UserClientOpChoise();
        }

        private void UserClientOpChoise()
        {
            switch(Console.ReadLine())
            {
                case "1":
                    GetClient();
                    break;

                case "2":
                    GetAllClients();
                    break;

                case "3":
                    AddNewClient();
                    break;

                case "4":
                    RemoveClient();
                    break;

                case "5":
                    ChangeNameOfClient();
                    break;

                case "6":
                    ChangeAddressOfClient();
                    break;
            }
        }

        private void GetClient()
        {    
            try
            {
                Client client = _clientsManagmentService.GetClient(_userInputHelper.GetUserStringInput("What client you want to find?"));
                Console.WriteLine("Full name of client:" + client.FullName);
                Console.WriteLine("Address:");
                Console.WriteLine(client.Address.StreetName);
                Console.WriteLine(client.Address.HouseName);
                Console.WriteLine(client.Address.City);
                Console.WriteLine(client.Address.Country);
                Console.WriteLine(client.Address.Zip);
            }
            catch (ClientDoesnotExsistException ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }

        private void GetAllClients()
        {           
            Console.WriteLine("List with All Clients");
            foreach (var client in _clientsManagmentService.GetAllClients())
            {
                Console.WriteLine(client.FullName);
            }
        }

        private void AddNewClient()
        {                       
            Address address = new Address()
            {
                StreetName = _userInputHelper.GetUserStringInput("Street name"),
                HouseName = _userInputHelper.GetUserStringInput("House name"),
                City = _userInputHelper.GetUserStringInput("City"),
                Country = _userInputHelper.GetUserStringInput("Country"),
                Zip = _userInputHelper.GetUserShortInput("Zip")
            };

            Client client = new Client()
            {
                FullName = _userInputHelper.GetUserStringInput("Full name of client"),
                Address = address
            };

            _clientsManagmentService.AddNewClient(client);
            Console.WriteLine("Client has been saved");
        }

        private void RemoveClient()
        {
            _clientsManagmentService.RemoveClient(_userInputHelper.GetUserStringInput("Full name of client"));
            Console.WriteLine("Client has been removed");
        }

        private void ChangeNameOfClient()
        {
            string name = _userInputHelper.GetUserStringInput("Full name of client");
            string newName = _userInputHelper.GetUserStringInput("What will be new name of client");
            _clientsManagmentService.ChangeNameOfClient(name, newName);
            Console.WriteLine("Clients new name has been saved, please search with new name");

        }

        private void ChangeAddressOfClient()
        {  
            Address newAddress = new Address()
            {
                StreetName = _userInputHelper.GetUserStringInput("Street name"),
                HouseName = _userInputHelper.GetUserStringInput("House name"),
                City = _userInputHelper.GetUserStringInput("City"),
                Country = _userInputHelper.GetUserStringInput("Country"),
                Zip = _userInputHelper.GetUserShortInput("Zip")
            };

            _clientsManagmentService.ChangeAddressOfClient(_userInputHelper.GetUserStringInput("Full name of client"), newAddress);
            Console.WriteLine("Clients address has been saved");
        }
    }
}
