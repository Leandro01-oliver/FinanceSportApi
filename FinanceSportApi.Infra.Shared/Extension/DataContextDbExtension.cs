using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using FinanceSportApi.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FinanceSportApi.Infra.Shared.Extension
{
    public static class DataContextDbExtension
    {
        public static IServiceCollection AddDataContextDb(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<DataContext>(options =>
                options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 34)),
                 b => b.MigrationsAssembly("FinanceSportApi.Infra.Data")));

            return services;
        }
    }
}
