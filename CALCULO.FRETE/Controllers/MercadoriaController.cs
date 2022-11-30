using Microsoft.AspNetCore.Mvc;
using CALCULOFRETE.Controllers.RequestExemples;
using CALCULOFRETE.Model;
using CALCULOFRETE.Service;
using Swashbuckle.AspNetCore.Filters;

namespace CALCULOFRETE.Controllers
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

        [HttpGet("obter")]
        public async Task<IActionResult> ObterAsync()
        {
            var mercadoria = await _mercadoria.ObterAsync();
            return Ok(mercadoria);
        }

        [HttpPost("obterPorId")]
        public async Task<IActionResult> ObterPorIdAsync(Guid id)
        {
            var mercadoria = await _mercadoria.ObterPorIdAsync(id);
            return Ok(mercadoria);
        }

        [HttpPost("cadastrar")]
        [SwaggerRequestExample(typeof(Cliente), typeof(MercadoriaCadastrarRequestExamples))]
        public async Task<IActionResult> CadastrarAsync([FromBody] Mercadoria mercadoria)
        {
            try
            {
                await _mercadoria.CadastrarAsync(mercadoria);
                return Ok(mercadoria);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("atualizar")]
        [SwaggerRequestExample(typeof(Cliente), typeof(MercadoriaAtualizarRequestExamples))]
        public async Task<IActionResult> AtualizarAsync([FromBody] Mercadoria mercadoria, Guid id)
        {
            try
            {
                await _mercadoria.AtualizarAsync(mercadoria, id);
                return Ok(mercadoria);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("remover")]
        public async Task<IActionResult> RemoverAsync(Guid id)
        {
            try
            {
                await _mercadoria.RemoverAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
