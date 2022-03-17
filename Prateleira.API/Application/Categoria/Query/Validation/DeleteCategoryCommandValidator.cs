using FluentValidation;
using Prateleira.API.Application.Categoria.Command;

namespace Prateleira.API.Application.Categoria.Query.Validation
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty();
        }
    }
}
