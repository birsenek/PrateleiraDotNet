using Microsoft.AspNetCore.Mvc;

namespace Prateleira.API.Controllers
{   [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok("Olá controller");
        }
    }
}
