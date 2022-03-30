using MediatR;
using Prateleira.API.Application.Estoque.Query;
using Prateleira.Infrastructure.Data.Contract;

namespace Prateleira.API.Application.Estoque.Handler
{
    public class ProdutoEstoqueQueryHandler : IRequestHandler<ProdutoEstoqueQuery, Domain.Estoque>
    {
        private readonly IGenericRepository<Domain.Estoque> _genericRepository;

        public ProdutoEstoqueQueryHandler(IGenericRepository<Domain.Estoque> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Domain.Estoque> Handle(ProdutoEstoqueQuery request, CancellationToken cancellationToken)
        {
            var estoque = await _genericRepository.GetAllAsync(
                    noTracking: true,
                    filter: x => x.ProdutoId == request.IdProduto,
                    cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            return estoque.FirstOrDefault();
        }
    }
}
