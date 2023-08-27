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
            services.AddTransient<IServiceAudit<MongoAuditLogDto>, MongoServiceAudit>();

            if (!istestingEnvironment)
            {
                services.AddScoped<IWsdlClient, WsdlClient>();
            }
            else
            {
                //Mocking
                services.AddScoped<IWsdlClient, WsdlClientMock>();
            }
                 services.AddTransient<IWsdlServiceHelper, WsdlServiceHelper>();
            services.AddScoped<Adapter>();
            return services;
        }

    }
}
