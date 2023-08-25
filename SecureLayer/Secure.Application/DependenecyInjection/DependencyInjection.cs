using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Secure.Presistence.Context;

namespace Secure.Application.DependenecyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
              services.AddDbContext<SqlDbContext>(c => c.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
            var context = services.BuildServiceProvider().GetRequiredService<SqlDbContext>();
            MockWsdlResponseSeeds.MockWsdlResponseSeedsAsync(context);

            services.AddTransient<MockWsdlResponseSeeds>();
            services.AddTransient<IWsdlRepositry, WsdlRepositry>();

            services.AddScoped<IMongoRepository<MongoAuditLogEntity>, MongoRepository<MongoAuditLogEntity>>();
            return services;
        }
    }
}

