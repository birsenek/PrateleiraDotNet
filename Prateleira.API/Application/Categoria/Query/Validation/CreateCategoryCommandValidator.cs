using FluentValidation;
using Prateleira.API.Application.Categoria.Command;

namespace Prateleira.API.Application.Categoria.Query.Validation
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Descricao)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
