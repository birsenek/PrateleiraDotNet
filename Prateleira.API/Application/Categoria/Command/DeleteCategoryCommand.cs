using FluentValidation.Results;
using MediatR;
using Prateleira.API.Application.Categoria.Query.Validation;
using System.Text.Json.Serialization;

namespace Prateleira.API.Application.Categoria.Command
{
    public class DeleteCategoryCommand : IRequest<bool>
    {
        public int Id { get; set; }
        [JsonIgnore]
        public ValidationResult Validation { get; }
        public DeleteCategoryCommand(int id)
        {
            Id = id;
            var validator = new DeleteCategoryCommandValidator();
            Validation = validator.Validate(this);
        }
    }

}
