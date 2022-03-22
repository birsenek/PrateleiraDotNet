using FluentValidation.Results;
using MediatR;
using Prateleira.API.Application.Produto.Query.Validation;
using System.Text.Json.Serialization;

namespace Prateleira.API.Application.Produto.Command
{
    public class CreateProductCommand : IRequest<bool>
    {
        public string Descricao { get; set; }

        public int[] IdCategorias { get; set; }
        [JsonIgnore]
        public ValidationResult Validation { get; }

        public CreateProductCommand(string descricao, int[] idCategorias)
        {
            Descricao = descricao;
            IdCategorias = idCategorias;

            var validator = new CreateProductCommandValidator();
            Validation = validator.Validate(this);
        }
    }
}
