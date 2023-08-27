using CommonComponent.Service.Features.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Secure.Application.Dtos;
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
            services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));
            services.AddSingleton<IMongoDbSettings>(serviceProvider =>
             serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
            services.AddTransient<MockWsdlResponseSeeds>();
            services.AddTransient<IWsdlRepositry, WsdlRepositry>();
            services.AddScoped<IMongoRepository<MongoAuditLogEntity>, MongoRepository<MongoAuditLogEntity>>();
            return services;
        }
    }
}

