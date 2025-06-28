using AutoMapper;
using FinanceSportApi.Domain.Entityes;
using FinanceSportApi.Domain.Models;

namespace FinanceSportApi.Infra.Data.Mappin
{
    public class ConfigurationMapping : Profile
    {
        public ConfigurationMapping()
        {
            CreateMap<Usuario, UsuarioVm>().ReverseMap().PreserveReferences();
            CreateMap<Usuario, UsuarioVm>().ReverseMap().PreserveReferences();
            CreateMap<Orcamento, OrcamentoVm>().ReverseMap().PreserveReferences();
            CreateMap<Investimento, InvestimentoVm>().ReverseMap().PreserveReferences();
        }
    }
}
