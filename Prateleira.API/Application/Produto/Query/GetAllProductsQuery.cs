using MediatR;

namespace Prateleira.API.Application.Produto.Query
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Domain.Produto>>
    {
    }
}
