﻿namespace Presentation.Service.DependenecyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructureService(configuration);
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IFactoryClient, FactoryClient>();
            services.AddScoped<IGetProfileStatus, GetProfileStatus>();
            services.AddScoped<IServiceAudit<ActionLogSqlDto>, ServiceAudit>();
            services.AddScoped<DeviceInformationAttribute>();
            return services;
        }

    }
}
