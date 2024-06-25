using BillingApi.Service.Interfaces;
using BillingApi.Service.Services;

namespace BillingApi.Infra
{
    public static class ServiceConfiguration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(ICustomerService), typeof(CustomerService));
        }
    }
}
