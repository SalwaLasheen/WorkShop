using Application.DependenecyInjection;
using ClientService.Contract;
using ClientService.Implementation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Features.Concrete;
using Services.Features.Interface;
using Services.Utilities.Attributes;
using System.Reflection;

namespace Services.DependenecyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceInjectionShared(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddInfrastructureSharedService();
            return services;
        }
        public static IServiceCollection AddServiceInjection(this IServiceCollection services, IConfiguration configuration, bool? isDevelopment)
        {
            services.AddInfrastructure(configuration);
            if (isDevelopment == true)
            {
                services.AddTransient<ICallWsdlService, CallWsdlService>();
                //Mocking
                services.AddScoped<IWsdlClient, MockWsdlClient>();
                //services.AddScoped<ICallWsdlService, CallWsdlServiceMocking>();
            }
            else
            {
                services.AddScoped<IWsdlClient, WsdlClient>();
                services.AddScoped<ICallWsdlService, CallWsdlService>();
            }
            services.AddScoped<IServiceAudit, MongoServiceAudit>();
            return services;
        }
        public static IServiceCollection AddServiceInjectionWeb(this IServiceCollection services, IConfiguration configuration, bool? isDevelopment)
        {
            //CALL CLIENT
            string baseUrl = configuration.GetSection("ClientBaseURl").Value.ToString();
            services.AddHttpClient("WsdlService", httpClient =>
           {
               httpClient.BaseAddress = new Uri(baseUrl);
               httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
           });

            services.AddInfrastructureWeb(configuration);
            if (isDevelopment == true)
            {
                //Mocking
                //  services.AddScoped<IConsumeAPI, ConsumeWsdlAPIMock>();
                services.AddScoped<IConsumeAPI, ConsumeAPI>();
            }
            else
            {
                services.AddScoped<IConsumeAPI, ConsumeAPI>();
            }
            services.AddScoped<IServiceAudit, ServiceAudit>();
            services.AddScoped<DeviceInformationAttribute>();
            return services;
        }

    }
}
