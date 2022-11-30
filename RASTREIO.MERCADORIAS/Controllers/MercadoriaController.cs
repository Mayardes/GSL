using Microsoft.AspNetCore.Mvc;
using RASTREIOMERCADORIAS.Service;

namespace RASTREIOMERCADORIAS.Controllers
{
    [ApiController]
    [Route("v1/mercadoria")]
    public class MercadoriaController : ControllerBase
    {
        private readonly MercadoriaServices _mercadoria;
        public MercadoriaController(MercadoriaServices mercadoriaService)
        {
            _mercadoria = mercadoriaService;
        }


        [HttpPost("rastrearMercadoriaPorId")]
        public async Task<IActionResult> ObterPorIdAsync(Guid id)
        {
            var mercadoria = await _mercadoria.RastrearMercadoriaPorIdAsync(id);
            return Ok(mercadoria);
        }

        [HttpPost("inserirStatus")]
        public async Task<IActionResult> InserirStatusAsync(Guid id, string status)
        {
            var mercadoria = await _mercadoria.InserirStatusAsync(id, status);
            return Ok(mercadoria);
        }
    }
}
