using FluentValidation;
using Prateleira.API.Application.Categoria.Command;

namespace Prateleira.API.Application.Categoria.Query.Validation
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Descricao)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
