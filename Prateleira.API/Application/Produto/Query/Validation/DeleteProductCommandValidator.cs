using FluentValidation;
using Prateleira.API.Application.Produto.Command;

namespace Prateleira.API.Application.Produto.Query.Validation
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty();
        }
    }
}
