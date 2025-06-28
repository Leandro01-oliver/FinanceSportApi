using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using FinanceSportApi.Infra.Data.Mappin;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceSportApi.Infra.Shared
{
    public static class MappingExtension
    {
        public static void AddAutoMapperConf(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ConfigurationMapping>();
                cfg.AddExpressionMapping();
            });

            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
