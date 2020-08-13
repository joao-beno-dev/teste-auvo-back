using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;

namespace DB
{
    public static class OracleDependency
    {
        public static void AddOracleDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BaseContext>(options =>
            {
                var datasource = configuration["database:oracle:server"];
                var username = configuration["database:oracle:username"];
                var password = configuration["database:oracle:password"];

                options.UseOracle($"User Id={username};Password={password};Data source={datasource}");
            });
        }
    }
}