using MediatR;
using Prateleira.API.Application.Categoria.Query;
using Prateleira.Infrastructure.Data.Contract;

namespace Prateleira.API.Application.Categoria.Handler
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<Domain.Categoria>>
    {
        private readonly IGenericRepository<Domain.Categoria> _categoriaRepository;

        public GetAllCategoriesQueryHandler(IGenericRepository<Domain.Categoria> categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<IEnumerable<Domain.Categoria>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _categoriaRepository.GetAllAsync(
                noTracking: true,
                cancellationToken: cancellationToken
                ).ConfigureAwait(false);
        }
    }
}
