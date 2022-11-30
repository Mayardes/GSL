using CALCULOFRETE.Service;
using Microsoft.AspNetCore.Mvc;

namespace CALCULOFRETE.Controllers
{
    [ApiController]
    [Route("v1/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteServices _clienteServices;
        public ClienteController(ClienteServices clienteServices)
        {
            _clienteServices = clienteServices;
        }

        [HttpPost("obterPorCpf")]
        public async Task<IActionResult> ObterPorIdAsync(string cpf)
        {
            var cliente = await _clienteServices.ObterPorCpfAsync(cpf);
            return Ok(cliente);
        }
    }
}
