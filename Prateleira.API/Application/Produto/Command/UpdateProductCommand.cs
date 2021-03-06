using FluentValidation.Results;
using MediatR;
using Prateleira.API.Application.Produto.Query.Validation;
using System.Text.Json.Serialization;

namespace Prateleira.API.Application.Produto.Command
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public int[] IdCategorias { get; set; }
        [JsonIgnore]
        public ValidationResult Validation { get; }
        public UpdateProductCommand(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
            var validator = new UpdateProductCommandValidator();
            Validation = validator.Validate(this);
        }
    }
}
