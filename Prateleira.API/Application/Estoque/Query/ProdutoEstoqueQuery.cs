using MediatR;

namespace Prateleira.API.Application.Estoque.Query
{
    public class ProdutoEstoqueQuery : IRequest<Domain.Estoque>
    {
        public int IdProduto { get; set; }
    }
}
