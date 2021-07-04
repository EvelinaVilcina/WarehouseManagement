using System;
using WarehouseManagement.Ui.Routers;

namespace WarehouseManagement.Ui
{
    public class ChoseManagementRouter
    {
        private readonly ProductManagementRouter _productMannagmentRouter;
        private readonly ClientManagementController _clientManagementControler;
        private readonly OrderManagementController _orderManagementController;

        public ChoseManagementRouter(ProductManagementRouter productMannagmentRouter, ClientManagementController clientManagementController, OrderManagementController orderManagementController)
        {
            _productMannagmentRouter = productMannagmentRouter;
            _clientManagementControler = clientManagementController;
            _orderManagementController = orderManagementController;
        }

        public void Start()
        {
            Console.WriteLine("Write number of your Management Service!");
            Console.WriteLine("1 - Product Management");
            Console.WriteLine("2 - Client Management");
            Console.WriteLine("3 - Order Management");

            switch (Console.ReadLine())
            {
                case "0":
                    return;
                case "1":
                    _productMannagmentRouter.Start();
                    break;

                case "2":
                    _clientManagementControler.Start();
                    break;

                case "3":
                    _orderManagementController.Start();
                    break;
            }
            Start();
        }
    }
}
