using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PlatformService.ActionFilters.Platforms;
using PlatformService.AsyncDataServices;
using PlatformService.Data;
using PlatformService.Services.Platforms;
using PlatformService.SyncDataServices.Http;
using System;

namespace PlatformService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opt=> opt.UseInMemoryDatabase("InMem"));

            // services.AddDbContext<AppDbContext>(opt=> 
            //     opt.UseSqlServer(Configuration.GetConnectionString("PlatformsConnection")));
            services.AddScoped<FilterAttributeExample>();
            services.AddScoped<IPlatformRepo, PlatformRepo>();
            services.AddScoped<IPlatformService, PlatformServiceImplementation>();

            services.AddHttpClient<ICommandDataClient, CommandDataClient>();
            services.AddSingleton<IMessageBusClient, MessageBusClient>();

            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PlatformService", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PlatformService v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            PrepDb.PrepPopulation(app, env.IsProduction());
            
        }
    }
}
