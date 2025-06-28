using FinanceSportApi.Domain.Entityes;
using FinanceSportApi.Domain.Models;

namespace FinanceSportApi.Infraestruture.Data.Mapping
{
    public static class OrcamentoMapping
    {
        public static OrcamentoVm ToViewModel(this Orcamento orcamento)
        {
            if (orcamento == null) return null;

            return new OrcamentoVm
            {
                Id = orcamento.Id,
                ValorMensal = orcamento.ValorMensal,
                ValorReservadoInvestimentos = orcamento.ValorReservadoInvestimentos,
                UsuarioId = orcamento.UsuarioId,
                Usuario = new UsuarioVm
                {
                    Id = orcamento.Usuario.Id,
                    Nome = orcamento.Usuario.Nome
                }
            };
        }

        public static Orcamento ToEntity(this OrcamentoVm orcamentoVm)
        {
            if (orcamentoVm == null) return null;

            return new Orcamento
            {
                Id = orcamentoVm.Id,
                ValorMensal = orcamentoVm.ValorMensal,
                ValorReservadoInvestimentos = orcamentoVm.ValorReservadoInvestimentos,
                UsuarioId = orcamentoVm.UsuarioId
            };
        }
    }
}
