using MediatR;
using Microsoft.AspNetCore.Mvc;
using Prateleira.API.Application.Categoria.Command;
using Prateleira.API.Application.Categoria.Query;

namespace Prateleira.API.Controllers
{   [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : Controller
    {
        private readonly IMediator _mediator;

        public CategoriaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCategories(CancellationToken cancellationToken)
        {

            var categorias = await _mediator.Send(new GetAllCategoriesQuery(), cancellationToken)
                .ConfigureAwait(false);

            return categorias.Any() ? Ok(categorias) : NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(CreateCategoryCommand createCategoryCommand, 
            CancellationToken cancellationToken)
        {
            if (!createCategoryCommand.Validation.IsValid)
                return BadRequest(createCategoryCommand.Validation.Errors);

            var sucesso = await _mediator.Send(createCategoryCommand, cancellationToken)
                .ConfigureAwait(false);

            return Ok(sucesso);
        }
    }
}
