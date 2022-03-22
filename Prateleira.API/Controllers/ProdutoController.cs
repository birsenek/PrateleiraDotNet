using MediatR;
using Microsoft.AspNetCore.Mvc;
using Prateleira.API.Application.Produto.Command;
using Prateleira.API.Application.Produto.Query;

namespace Prateleira.API.Controllers
{   [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : Controller
    {
        private readonly IMediator _mediator;

        public ProdutoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        
        public async Task<IActionResult> GetAllProducts(CancellationToken cancellationToken)
        {
            var produtos = await _mediator.Send(new GetAllProductsQuery(), cancellationToken)
                .ConfigureAwait(false);

            return produtos.Any() ? Ok(produtos) : NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public async Task<IActionResult> Create(CreateProductCommand createProductCommand, CancellationToken cancellationToken)
        {
            if (!createProductCommand.Validation.IsValid)
                return BadRequest(createProductCommand.Validation.Errors);

            var sucesso = await _mediator.Send(createProductCommand, cancellationToken).ConfigureAwait(false);

            return Ok(sucesso);
        }

    }
}
