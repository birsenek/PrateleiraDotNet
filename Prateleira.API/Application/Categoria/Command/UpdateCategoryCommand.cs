using FluentValidation.Results;
using MediatR;
using Prateleira.API.Application.Categoria.Query.Validation;
using System.Text.Json.Serialization;

namespace Prateleira.API.Application.Categoria.Command
{
    public class UpdateCategoryCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        [JsonIgnore]
        public ValidationResult Validation { get; }
        public UpdateCategoryCommand(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
            var validator = new UpdateCategoryCommandValidator();
            Validation = validator.Validate(this);
        }
    }
}
