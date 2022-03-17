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

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(UpdateCategoryCommand updateCategoryCommand, CancellationToken cancellationToken)
        {
            if (!updateCategoryCommand.Validation.IsValid)
                return BadRequest(updateCategoryCommand.Validation.Errors);

            var sucesso = await _mediator.Send(updateCategoryCommand, cancellationToken).ConfigureAwait(false);

            if (!sucesso)
                return Ok("Categoria não encontrada.");
            else
                return Ok(sucesso);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(DeleteCategoryCommand deleteCategoryCommand, CancellationToken cancellationToken)
        {
            if (!deleteCategoryCommand.Validation.IsValid)
                return BadRequest(deleteCategoryCommand.Validation.Errors);

            var sucesso = await _mediator.Send(deleteCategoryCommand, cancellationToken).ConfigureAwait(false);

            if (!sucesso)
                return Ok("ID não encontrado.");
            else
                return Ok(sucesso);
        }
    }
}
