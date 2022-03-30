using MediatR;
using Prateleira.API.Application.Produto.Query;
using Prateleira.Infrastructure.Data.Contract;

namespace Prateleira.API.Application.Produto.Handler
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Domain.Produto>>
    {
        private readonly IGenericRepository<Domain.Produto> _produtoRepository;

        public GetAllProductsQueryHandler(IGenericRepository<Domain.Produto> produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<Domain.Produto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _produtoRepository.GetAllAsync(
                noTracking: true,
                includeProperties: "Categorias,Estoque",
                cancellationToken: cancellationToken
                ).ConfigureAwait(false);
        }
    }
}
