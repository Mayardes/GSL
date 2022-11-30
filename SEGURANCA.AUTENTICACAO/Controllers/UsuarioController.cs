using Microsoft.AspNetCore.Mvc;
using SEGURANCAAUTENTICACAO.Controllers.RequestExemples;
using SEGURANCAAUTENTICACAO.Model;
using SEGURANCAAUTENTICACAO.RabbitMQService;
using SEGURANCAAUTENTICACAO.Service;
using Swashbuckle.AspNetCore.Filters;

namespace SEGURANCAAUTENTICACAO.Controllers
{
    [ApiController]
    [Route("v1/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioServices _UsuarioService;
        private readonly RabbitMQPublisherService<Usuario> _rabbitMQPublisherService;
        public UsuarioController(UsuarioServices UsuarioService, RabbitMQPublisherService<Usuario> rabbitMQPublisherService)
        {
            _UsuarioService = UsuarioService;
            _rabbitMQPublisherService = rabbitMQPublisherService;
        }

        [HttpPost("cadastrar")]
        [SwaggerRequestExample(typeof(Usuario), typeof(UsuarioCadastrarRequestExamples))]
        public async Task<IActionResult> CadastrarAsync([FromBody] Usuario Usuario)
        {
            try
            {
                 var result = await _UsuarioService.CadastrarAsync(Usuario);
                await _rabbitMQPublisherService.SendModel(Usuario);

                return Ok(Usuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
