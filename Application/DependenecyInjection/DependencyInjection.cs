using Application.Presistence.Context;
using Application.Repository.Concrete;
using Application.Repository.Interface;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParkBee.MongoDb.DependencyInjection;
using System.Reflection;

namespace Application.DependenecyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureSharedService(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }

        public static IServiceCollection AddInfrastructureWeb(this IServiceCollection services,IConfiguration configuration)
        {
            //TODO Remove It When unused Mocking
            services.AddDbContext<SqlDbContext>(c => c.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
            DependencyInjectionService(services);
            return services;
        }
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //TODO Remove It When unused Mocking
            services.AddMongoContext<MongoDbContext>(options => {
                options.ConnectionString = (configuration.GetConnectionString("MongoConnection"));
                options.DatabaseName = configuration.GetSection("DatabaseName").Value.ToString();
            });
           services.AddScoped<IMongoRepository<MongoAuditLogEntity>, MongoRepository<MongoAuditLogEntity>>();
            return services;
        }

        private static void DependencyInjectionService(IServiceCollection services)
        {
            //TODO Remove It When unused Mocking
            services.AddScoped<ISqlRepository<SqlResponseEntity>, SqlRepositry<SqlResponseEntity>>();
            services.AddScoped<ISqlRepository<ActionLogEntity>, SqlRepositry<ActionLogEntity>>();
           // services.AddScoped<IMongoRepository<MongoAuditLogEntity>, MongoRepository<MongoAuditLogEntity>>();
        }
    }
}
