using MediatR;

namespace Prateleira.API.Application.Categoria.Query
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<Domain.Categoria>>
    {
    }
}
