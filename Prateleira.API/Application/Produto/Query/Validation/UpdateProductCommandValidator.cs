using FluentValidation;
using Prateleira.API.Application.Produto.Command;

namespace Prateleira.API.Application.Produto.Query.Validation
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator() 
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
