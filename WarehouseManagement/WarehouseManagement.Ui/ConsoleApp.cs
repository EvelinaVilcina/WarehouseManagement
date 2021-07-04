using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManagement.Ui
{
    public class ConsoleApp
    {
        public void StartApplication()
        {
            Startup startUp = new Startup();
            ServiceProvider serviceProvider = startUp.GetApplicationServices();

            ChoseManagementRouter mainRouter = serviceProvider.GetService<ChoseManagementRouter>();
            mainRouter.Start();
        }
    }
}
