using FinanceSportApi.Infra.Data.Repository.Interface;
using FinanceSportApi.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceSportApi.Helpers.Extensions
{
    public static class RepositoryCollectionExtension
    {
        public static IServiceCollection AddRepositoryes(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IInvestimentoRepository, InvestimentoRepository>();
            services.AddScoped<IInvestimentoRepository, InvestimentoRepository>();
            services.AddScoped<ITransacaoRepository, TransacaoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            return services;
        }
    }
}
