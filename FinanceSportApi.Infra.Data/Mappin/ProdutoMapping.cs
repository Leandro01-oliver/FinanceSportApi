using FinanceSportApi.Domain.Entityes;
using FinanceSportApi.Domain.Models;

namespace FinanceSportApi.Infraestruture.Data.Mapping
{
    public static class ProdutoMapping
    {
        public static ProdutoVm ToViewModel(this Produto produto)
        {
            if (produto == null) return null;

            return new ProdutoVm
            {
                ProdutoId = produto.ProdutoId,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Valor = produto.Valor,
                Quantidade = produto.Quantidade
            };
        }

        public static Produto ToEntity(this ProdutoVm produtoVm)
        {
            if (produtoVm == null) return null;

            return new Produto
            {
                ProdutoId = produtoVm.ProdutoId,
                Nome = produtoVm.Nome,
                Descricao = produtoVm.Descricao,
                Valor = produtoVm.Valor,
                Quantidade = produtoVm.Quantidade
            };
        }
    }

}
