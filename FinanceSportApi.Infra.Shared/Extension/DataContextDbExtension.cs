using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FinanceSportApi.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using FinanceSportApi.Domain.Enums;

namespace FinanceSportApi.Infra.Shared.Extension
{
    public static class DataContextDbExtension
    {
        public static IServiceCollection AddDataContextDb(this IServiceCollection services, IConfiguration configuration, TipoDb  tipoDb)
        {
            if (tipoDb.Equals(TipoDb.SQL))
            {
                var connectionString = configuration.GetConnectionString("SqlServer");
                services.AddDbContext<DataContext>(options =>
                    options.UseSqlServer(connectionString, b =>
                        b.MigrationsAssembly("FinanceSportApi.Infra.Data")));
            }
            else
            {
                var connectionString = configuration.GetConnectionString("MySql");

                services.AddDbContext<DataContext>(options =>
                    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 34)),
                     b => b.MigrationsAssembly("FinanceSportApi.Infra.Data")));

            }

            return services;
        }
    }
}
