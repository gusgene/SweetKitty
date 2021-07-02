using DataAccess.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace DataAccess.PgSql
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IDbContext, AppDbContext>(builder => builder.UseNpgsql(configuration.GetConnectionString("ApplicationDatabase")));
            return services;
        }
    }
}
