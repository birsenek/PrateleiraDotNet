using MediatR;
using Prateleira.API.Application.Estoque.Command;
using Prateleira.Infrastructure.Data.Contract;

namespace Prateleira.API.Application.Estoque.Handler
{
    public class EstoqueCommandHandler : IRequestHandler<EstoqueCommand, bool>
    {
        private readonly IGenericRepository<Domain.Estoque> _genericRepository;
        private readonly IGenericRepository<Domain.Produto> _produtoRepository;

        public EstoqueCommandHandler(IGenericRepository<Domain.Estoque> genericRepository, 
            IGenericRepository<Domain.Produto> produtoRepository)
        {
            _genericRepository = genericRepository;
            _produtoRepository = produtoRepository;
        }

        public async Task<bool> Handle(EstoqueCommand request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.GetByKeysAsync(cancellationToken, request.IdProduto)
                    ?? throw new ArgumentException("Id do produto inválido.");

            var estoque = new Domain.Estoque
            {
                ProdutoId = produto.Id,
                InfoCompra = new Domain.Qualitativo
                {
                    PrecoUnidade = request.PrecoUnitario,
                    Quantidade = request.Quantidade,
                    UnidadeMedida = request.UnidadeMedida
                }
            };

            await _genericRepository.AddAsync(estoque, cancellationToken).ConfigureAwait(false);
            return await _genericRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
