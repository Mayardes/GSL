using Microsoft.AspNetCore.Mvc;
using CALCULOFRETE.Controllers.RequestExemples;
using CALCULOFRETE.Model;
using CALCULOFRETE.Service;
using Swashbuckle.AspNetCore.Filters;

namespace CALCULOFRETE.Controllers
{
    [ApiController]
    [Route("v1/frete")]
    public class FreteController : ControllerBase
    {
        private readonly MercadoriaServices _mercadoria;
        public FreteController(MercadoriaServices mercadoriaService)
        {
            _mercadoria = mercadoriaService;
        }

        [HttpPost("calcular")]
        public async Task<IActionResult> CalcularFreteAsync()
        {
            var mercadoria = await _mercadoria.ObterAsync();
            return Ok(mercadoria);
        }
    }
}
