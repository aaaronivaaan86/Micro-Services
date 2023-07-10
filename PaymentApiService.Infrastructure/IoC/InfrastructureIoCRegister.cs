using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaymentApiService.Domain.Configuration;
using PaymentApiService.Domain.Interfaces.clients;
using PaymentApiService.Infrastructure.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApiService.Infrastructure.IoC
{
    public static class InfrastructureIoCRegister
    {
        public static void AddInfrastructurLayer(this IServiceCollection services, IConfiguration configuration)
        {
            AddRepositories(services);
            AddServices(services);
            AddClients(services);
            AddConfigurations(services, configuration);
        }
        private static void AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<OpenPaySettings>(configuration.GetSection("OpenPaySettings"));
        }
        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IOpenPayCustomerClient, OpenPayCustomerClient>();
        }

        private static void AddServices(this IServiceCollection services)
        {

        }

        private static void AddClients(this IServiceCollection services)
        {

        }

    }
}
