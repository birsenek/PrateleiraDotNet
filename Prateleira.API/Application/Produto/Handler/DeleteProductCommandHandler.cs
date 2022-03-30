using MediatR;
using Prateleira.API.Application.Produto.Command;
using Prateleira.Infrastructure.Data.Contract;

namespace Prateleira.API.Application.Produto.Handler
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IGenericRepository<Domain.Produto> _produtoRepository;

        public DeleteProductCommandHandler(IGenericRepository<Domain.Produto> produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.GetByKeysAsync(cancellationToken,
                request.Id).ConfigureAwait(false);

            if (produto != null)
            {
                _produtoRepository.Delete(produto);
                return await _produtoRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
            }
            else
                return false;
        }
    }
}
