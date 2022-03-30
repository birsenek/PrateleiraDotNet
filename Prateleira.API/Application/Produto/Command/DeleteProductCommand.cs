using FluentValidation.Results;
using MediatR;
using Prateleira.API.Application.Produto.Query.Validation;
using System.Text.Json.Serialization;

namespace Prateleira.API.Application.Produto.Command
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public int Id { get; set; }
        [JsonIgnore]
        public ValidationResult Validation { get; }
        public DeleteProductCommand(int id)
        {
            Id = id;
            var validator = new DeleteProductCommandValidator();
            Validation = validator.Validate(this);
        }

    }
}
