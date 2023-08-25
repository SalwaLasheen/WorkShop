using CommonComponent.Service.Features.Interface;
using Secure.Application.Dtos;

namespace Secure.Service.DependenecyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddInfrastructure(configuration);
            var testingEnvironment = configuration.GetSection("IsTestingEnvironment").Value.ToString();
            var istestingEnvironment = testingEnvironment.ToLower() == "true";
           
            if (!istestingEnvironment)
            {
                services.AddScoped<IWsdlClient, WsdlClient>();
            }
            else
            {
                //Mocking
                services.AddScoped<IWsdlClient, WsdlClientMock>();
            }
            services.AddScoped<IWsdlServiceHelper, WsdlServiceHelper>();
            services.AddScoped<IServiceAudit<MongoAuditLogDto>, MongoServiceAudit>();
            services.AddScoped<Adapter>();
            return services;
        }

    }
}
