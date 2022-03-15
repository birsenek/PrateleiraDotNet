using FluentValidation.Results;
using MediatR;
using Newtonsoft.Json;
using Prateleira.API.Application.Categoria.Query.Validation;

namespace Prateleira.API.Application.Categoria.Command
{
    public class CreateCategoryCommand : IRequest<bool>
    {
        public string Descricao { get; set; }
        [JsonIgnore]
        public ValidationResult Validation { get; }

        public CreateCategoryCommand(string descricao)
        {
            Descricao = descricao;
            var validator = new CreateCategoryCommandValidator();
            validator.Validate(this);
        }
    }
}
