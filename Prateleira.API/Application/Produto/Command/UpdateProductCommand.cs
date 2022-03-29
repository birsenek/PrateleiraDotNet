using MediatR;

namespace Prateleira.API.Application.Produto.Command
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public int[] IdCategorias { get; set; }
    }
}
