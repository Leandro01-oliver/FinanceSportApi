using AutoMapper;
using FinanceSportApi.Domain.Entityes;
using FinanceSportApi.Domain.Models;
using FinanceSportApi.Infra.Data.Repository.Interface;
using FinanceSportApi.Service.Service.Interface;

namespace FinanceSportApi.Service.Service
{
    public class InvestimentoService : BaseService<InvestimentoVm, Investimento>, IInvestimentoService
    {
        private readonly IInvestimentoRepository _investimentoRepository;

        public InvestimentoService(IInvestimentoRepository investimentoRepository, IMapper mapper) : base(investimentoRepository, mapper)
        {
            _investimentoRepository = investimentoRepository;
        }
    }
}
