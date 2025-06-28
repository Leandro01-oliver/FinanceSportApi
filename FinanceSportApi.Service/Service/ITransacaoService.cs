using AutoMapper;
using FinanceSportApi.Domain.Entityes;
using FinanceSportApi.Domain.Models;
using FinanceSportApi.Infra.Data.Repository.Interface;
using FinanceSportApi.Service.Service.Interface;

namespace FinanceSportApi.Service.Service
{
    public class TransacaoService : BaseService<TransacaoVm, Transacao>, ITransacaoService
    {
        private readonly ITransacaoRepository _transacaoRepository;

        public TransacaoService(ITransacaoRepository transacaoRepository, IMapper mapper) : base(transacaoRepository, mapper)
        {
            _transacaoRepository = transacaoRepository;
        }
    }
}
