using AutoMapper;
using FinanceSportApi.Domain.Entityes;
using FinanceSportApi.Domain.Models;
using FinanceSportApi.Infra.Data.Repository.Interface;
using FinanceSportApi.Service.Service.Interface;

namespace FinanceSportApi.Service.Service
{
    public class OrcamentoService : BaseService<OrcamentoVm, Orcamento>, IOrcamentoService
    {
        private readonly IOrcamentoRepository _orcamentoRepository;

        public OrcamentoService(IOrcamentoRepository orcamentoRepository, IMapper mapper) : base(orcamentoRepository, mapper)
        {
            _orcamentoRepository = orcamentoRepository;
        }
    }
}
