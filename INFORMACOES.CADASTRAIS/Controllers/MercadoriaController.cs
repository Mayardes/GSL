using INFORMACOESCADASTRAIS.Controllers.RequestExemples;
using INFORMACOESCADASTRAIS.Model;
using INFORMACOESCADASTRAIS.RabbitMQService;
using INFORMACOESCADASTRAIS.Service;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace INFORMACOESCADASTRAIS.Controllers
{
    [ApiController]
    [Route("v1/mercadoria")]
    public class MercadoriaController : ControllerBase
    {
        private readonly MercadoriaServices _mercadoria;
        private readonly RabbitMQPublisherService<Mercadoria> _rabbitMQPublisherService;
        public MercadoriaController(MercadoriaServices mercadoriaService, RabbitMQPublisherService<Mercadoria> rabbitMQPublisherService)
        {
            _mercadoria = mercadoriaService;
            _rabbitMQPublisherService = rabbitMQPublisherService;
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
                await _rabbitMQPublisherService.SendModel(mercadoria);

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
