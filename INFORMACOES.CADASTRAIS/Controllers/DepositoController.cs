using INFORMACOESCADASTRAIS.Controllers.RequestExemples;
using INFORMACOESCADASTRAIS.Dto;
using INFORMACOESCADASTRAIS.Model;
using INFORMACOESCADASTRAIS.RabbitMQService;
using INFORMACOESCADASTRAIS.Service;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace INFORMACOESCADASTRAIS.Controllers
{
    [ApiController]
    [Route("v1/depositos")]
    public class DepositoController : ControllerBase
    {
        private readonly DepositoServices _DepositoService;
        private readonly RabbitMQPublisherService<Deposito> _rabbitMQPublisherService;
        public DepositoController(DepositoServices DepositoService, RabbitMQPublisherService<Deposito> rabbitMQPublisherService)
        {
            _DepositoService = DepositoService;
            _rabbitMQPublisherService = rabbitMQPublisherService;
        }

        [HttpGet("obter")]
        public async Task<IActionResult> ObterAsync()
        {
            var Deposito = await _DepositoService.ObterAsync();
            return Ok(Deposito);
        }

        [HttpPost("obterPorId")]
        public async Task<IActionResult> ObterPorIdAsync(Guid id)
        {
            var Deposito = await _DepositoService.ObterPorIdAsync(id);
            return Ok(Deposito);
        }

        [HttpPost("cadastrar")]
        [SwaggerRequestExample(typeof(Cliente), typeof(DepositoCadastrarRequestExamples))]
        public async Task<IActionResult> CadastrarAsync([FromBody] DepositoDto depositoDto)
        {
            var deposito = new Deposito()
            {
                Id = depositoDto.Id,
                Nome = depositoDto.Nome,
                Endereco = depositoDto.Endereco,
                Contato = depositoDto.Contato
            };

            try
            {
                await _rabbitMQPublisherService.SendModel(deposito);
                await _DepositoService.CadastrarAsync(deposito);
                return Ok(depositoDto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("atualizar")]
        [SwaggerRequestExample(typeof(Cliente), typeof(DepositoAtualizarRequestExamples))]
        public async Task<IActionResult> AtualizarAsync([FromBody] DepositoDto depositoDto, Guid id)
        {
            var deposito = new Deposito()
            {
                Id = depositoDto.Id,
                Nome = depositoDto.Nome,
                Endereco = depositoDto.Endereco,
                Contato = depositoDto.Contato
            };

            try
            {
                await _DepositoService.AtualizarAsync(deposito, id);
                return Ok(depositoDto);
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
                await _DepositoService.RemoverAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
