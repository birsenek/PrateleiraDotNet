using MediatR;
using Prateleira.API.Application.Produto.Command;
using Prateleira.Infrastructure.Data.Contract;

namespace Prateleira.API.Application.Produto.Handler
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
    {
        private readonly IGenericRepository<Domain.Produto> _produtoRepository;
        private readonly IGenericRepository<Domain.Categoria> _genericRepository;
        public CreateProductCommandHandler(IGenericRepository<Domain.Produto> produtoRepository,
            IGenericRepository<Domain.Categoria> genericRepository)
        {
            _produtoRepository = produtoRepository;
            _genericRepository = genericRepository;
        }

        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validation.IsValid)
                return false;

            var categorias = _genericRepository.GetAll()
                .Where(x => request.IdCategorias.Contains(x.Id)).ToList();

            var produto = new Domain.Produto
            {
                Descricao = request.Descricao,
                Categorias = categorias
            };

            await _produtoRepository.AddAsync(produto, cancellationToken)
                .ConfigureAwait(false);

            return await _produtoRepository.CommitAsync(cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
