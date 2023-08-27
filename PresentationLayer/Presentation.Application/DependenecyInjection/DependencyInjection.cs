namespace Presentation.Application.DependenecyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddDbContext<SqlDbContext>(c => c.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
            DependencyInjectionService(services);
            return services;
        }

        private static void DependencyInjectionService(IServiceCollection services)
        {
            services.AddScoped<ISqlRepository<SqlResponseEntity>, SqlRepositry<SqlResponseEntity>>();
            services.AddScoped<ISqlRepository<ActionLogEntity>, SqlRepositry<ActionLogEntity>>();
        }
    }
}
