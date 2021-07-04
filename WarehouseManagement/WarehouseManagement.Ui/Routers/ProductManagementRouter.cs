using Microsoft.Extensions.DependencyInjection;
using System;

namespace WarehouseManagement.Ui.Routers
{
    public class ProductManagementRouter
    {
        private readonly ProductManagementController _productManagementController;

        public ProductManagementRouter(ProductManagementController productManagementController)
        {
            _productManagementController = productManagementController;
        }
    

        public void Start()
        {
            Console.WriteLine("Write number of your Product Management Service operation!");
            Console.WriteLine("1 - AddProduct");
            Console.WriteLine("2 - GetAllAvailableProducts");
            Console.WriteLine("3 - GetProduct");
            Console.WriteLine("4 - ChangePrice");
            Console.WriteLine("5 - AddToStock");
            Console.WriteLine("6 - RemoveFromStock");
            Console.WriteLine("7 - MarkOutOfStock");
            Console.WriteLine("8 - RemoveProduct");
            Console.WriteLine("0 - Back to beginig");
            UserProductOpChoise(Console.ReadLine());
        }

        private void UserProductOpChoise(string ProdOpChoise)
        {
            switch (ProdOpChoise)
            {
                case "1":
                    _productManagementController.AddProduct();
                    break;

                case "2":
                    _productManagementController.GetAllAvailableProducts();
                    break;

                case "3":
                    _productManagementController.GetProduct();
                    break;

                case "4":
                    _productManagementController.ChangePrice();
                    break;

                case "5":
                    _productManagementController.AddToStock();
                    break;

                case "6":
                    _productManagementController.RemoveFromStock();
                    break;

                case "7":
                    _productManagementController.MarkOutOfStock();
                    break;

                case "8":
                    _productManagementController.RemoveProduct();
                    break;
            }
        }
    }
}
