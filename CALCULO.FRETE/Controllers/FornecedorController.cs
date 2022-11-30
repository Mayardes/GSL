using Microsoft.AspNetCore.Mvc;
using SISTEMALEGADO.Controllers.RequestExemples;
using SISTEMALEGADO.Dto;
using SISTEMALEGADO.Model;
using SISTEMALEGADO.Service;
using Swashbuckle.AspNetCore.Filters;

namespace SISTEMALEGADO.Controllers
{
    [ApiController]
    [Route("v1/fornecedor")]
    public class FornecedorController : ControllerBase
    {
        private readonly FornecedorServices _fornecedor;
        public FornecedorController(FornecedorServices fornecedorService)
        {
            _fornecedor = fornecedorService;
        }

        [HttpGet("obter")]
        public async Task<IActionResult> ObterAsync()
        {
            var fornecedor = await _fornecedor.ObterAsync();
            return Ok(fornecedor);
        }

        [HttpPost("obterPorId")]
        public async Task<IActionResult> ObterPorIdAsync(Guid id)
        {
            var fornecedor = await _fornecedor.ObterPorIdAsync(id);
            return Ok(fornecedor);
        }

        [HttpPost("cadastrar")]
        [SwaggerRequestExample(typeof(Cliente), typeof(FornecedorCadastrarRequestExamples))]
        public async Task<IActionResult> CadastrarAsync([FromBody] FornecedorDto fornecedorDto)
        {
            var fornecedor = new Fornecedor()
            {
                Id = fornecedorDto.Id,
                Nome = fornecedorDto.Nome,
                Descricao = fornecedorDto.Descricao,
                CpfCnpj = fornecedorDto.CpfCnpj,
                Contato = fornecedorDto.Contato,
                Email = fornecedorDto.Email,
                RazaoSocial = fornecedorDto.RazaoSocial
            };

            try
            {
                await _fornecedor.CadastrarAsync(fornecedor);
                return Ok(fornecedorDto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("atualizar")]
        [SwaggerRequestExample(typeof(Cliente), typeof(FornecedorAtualizarRequestExamples))]
        public async Task<IActionResult> AtualizarAsync([FromBody] FornecedorDto fornecedorDto, Guid id)
        {
            var fornecedor = new Fornecedor()
            {
                Id = fornecedorDto.Id,
                Nome = fornecedorDto.Nome,
                Descricao = fornecedorDto.Descricao,
                CpfCnpj = fornecedorDto.CpfCnpj,
                Contato = fornecedorDto.Contato,
                Email = fornecedorDto.Email,
                RazaoSocial = fornecedorDto.RazaoSocial
            };

            try
            {
                await _fornecedor.AtualizarAsync(fornecedor, id);
                return Ok(fornecedorDto);
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
                await _fornecedor.RemoverAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
