using Microsoft.AspNetCore.Mvc;
using CALCULOFRETE.Model;
using CALCULOFRETE.RabbitMQService;
using CALCULOFRETE.Service;
using Swashbuckle.AspNetCore.Filters;

namespace CALCULOFRETE.Controllers
{
    [ApiController]
    [Route("v1/frete")]
    public class FreteController : ControllerBase
    {
        private readonly ClienteServices _clienteService;
        public FreteController(ClienteServices clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost("calcular")]
        public async Task<IActionResult> CadastrarAsync([FromBody] Cliente cliente)
        {
            try
            {
                

                return Ok(cliente);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
