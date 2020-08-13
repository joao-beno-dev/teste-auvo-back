using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;

namespace DB
{
    public static class MsSqlDependency
    {
        public static void AddMsSqlDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BaseContext>(options =>
            {
                var server = configuration["database:mssql:server"];
                var port = configuration["database:mssql:port"];
                var database = configuration["database:mssql:db"];
                var username = configuration["database:mssql:username"];
                var password = configuration["database:mssql:password"];

                options.UseSqlServer($"Server={server},{port};Database={database};Uid={username};Pwd={password}");
            });
        }
    }
}