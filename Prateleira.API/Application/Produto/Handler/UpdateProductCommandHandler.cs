using MediatR;
using Prateleira.API.Application.Produto.Command;
using Prateleira.Infrastructure.Data.Contract;

namespace Prateleira.API.Application.Produto.Handler
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IGenericRepository<Domain.Produto> _genericRepository;

        public UpdateProductCommandHandler(IGenericRepository<Domain.Produto> genericRepository,
            IGenericRepository<Domain.Categoria> categoriaRepository)
        {
            _genericRepository = genericRepository;
            _categoriaRepository = categoriaRepository;
        }

        private readonly IGenericRepository<Domain.Categoria> _categoriaRepository;
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var produtos = await _genericRepository.GetAllAsync(
                noTracking: false,
                filter: x => x.Id == request.Id,
                includeProperties: "Categorias",
                cancellationToken: cancellationToken
                ).ConfigureAwait(false);

            var produto = produtos.FirstOrDefault() ??
                throw new ArgumentNullException($"Produto {request.Id} não encontrado.");

            produto.Descricao = request.Descricao;

            if (request.IdCategorias.Any())
            {
                var categorias = _categoriaRepository.GetAll()
                        .Where(x => request.IdCategorias.Contains(x.Id)).ToList();

                produto.Categorias = categorias;
            }

            _genericRepository.Update(produto);

            return await _genericRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
