using Microsoft.Extensions.DependencyInjection;
using WarehouseManagement.Services;
using WarehouseManagement.Ui.Routers;

namespace WarehouseManagement.Ui
{
    public class Startup
    {
        public ServiceProvider GetApplicationServices()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<ClientManagementService>();
            services.AddSingleton<CorectUserInputHelper>();
            services.AddSingleton<ProductManagementService>();
            services.AddSingleton<OrderManagementService>();

            services.AddSingleton<ProductManagementController>();
            services.AddSingleton<ClientManagementController>();
            services.AddSingleton<OrderManagementController>();

            services.AddSingleton<ChoseManagementRouter>();
            services.AddSingleton<ProductManagementRouter>();

            return services.BuildServiceProvider();
        }
    }
}
