using CA.Infraestructure.Repositories;
using CA.Infraestructure.Repositories.Interfaces;
using CA.Infraestructure.Services;
using CA.Infraestructure.Services.Interfaces;

namespace CA.Api.IoC
{
    public static class IoCRegister
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {

            AddRepositorieRegistration(services);
            AddServiceRegistration(services);

            return services;
        }

        public static IServiceCollection AddRepositorieRegistration(this IServiceCollection services)
        {
            services.AddTransient<IPlatformRepo, PlatformRepo>();


            return services;
        }

        public static IServiceCollection AddServiceRegistration(this IServiceCollection services)
        {

            services.AddTransient<IPlatformService, PlatformService>();
            return services;
        }



    }
}
