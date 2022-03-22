using FluentValidation;
using Prateleira.API.Application.Produto.Command;

namespace Prateleira.API.Application.Produto.Query.Validation
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Descricao)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.IdCategorias)
                .NotNull()
                .NotEmpty()
                .Must(x => x.Length > 0);
        }
    }
}
