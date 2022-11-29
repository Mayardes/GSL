﻿using Microsoft.AspNetCore.Mvc;
using SISTEMALEGADO.Controllers.RequestExemples;
using SISTEMALEGADO.Model;
using SISTEMALEGADO.Service;
using Swashbuckle.AspNetCore.Filters;

namespace SISTEMALEGADO.Controllers
{
    [ApiController]
    [Route("v1/clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteServices _clienteService;
        public ClienteController(ClienteServices clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("obter")]
        public async Task<IActionResult> ObterAsync()
        {
            var cliente = await _clienteService.ObterAsync();
            return Ok(cliente);
        }

        [HttpPost("obterPorId")]
        public async Task<IActionResult> ObterPorIdAsync(Guid id)
        {
            var cliente = await _clienteService.ObterPorIdAsync(id);
            return Ok(cliente);
        }

        [HttpPost("cadastrar")]
        [SwaggerRequestExample(typeof(Cliente), typeof(ClienteCadastrarRequestExamples))]
        public async Task<IActionResult> CadastrarAsync([FromBody] Cliente cliente)
        {
            try
            {
                 var result = await _clienteService.CadastrarAsync(cliente);

                return Ok(cliente);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("atualizar")]
        [SwaggerRequestExample(typeof(Cliente), typeof(ClienteAtualizarRequestExamples))]
        public async Task<IActionResult> AtualizarAsync([FromBody] Cliente cliente, Guid id)
        {
            try
            {
                await _clienteService.AtualizarAsync(cliente, id);
                return Ok(cliente);
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
                await _clienteService.RemoverAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}