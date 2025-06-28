using FinanceSportApi.Service.Service;
using FinanceSportApi.Service.Service.Interface;

namespace FinanceSportApi.Helpers.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseService<,>), typeof(BaseService<,>));
            services.AddScoped<IInvestimentoService, InvestimentoService>();
            services.AddScoped<IInvestimentoService, InvestimentoService>();
            services.AddScoped<ITransacaoService, TransacaoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            return services;
        }
    }
}
