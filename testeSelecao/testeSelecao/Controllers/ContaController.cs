using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using testeSelecao.Models;
using testeSelecao.Operations;

namespace testeSelecao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ContaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost(Name = "InserirConta")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> PostConta(Conta novaConta)
        {
            Operacoes operacao = new Operacoes();

            var inseriu = await operacao.InserirNovaConta(novaConta);
            if (inseriu)
            {
                return Ok($"Conta {novaConta.nome} criada com sucesso");
            }
            else
            {
                return BadRequest($"Falha ao criar a conta {novaConta.nome}");
            }
        }

        [HttpGet(Name = "SelecionarConta")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> GetConta(string conta)
        {
            Operacoes operacao = new Operacoes();

            var contaSelecionada = await operacao.SelecionarConta(conta);
            var jsonConta = JsonSerializer.Serialize(contaSelecionada);
            if (contaSelecionada?.Count() > 0)
            {
                return Ok(jsonConta);
            }
            else
            {
                return BadRequest("Nenhuma conta foi encontrada");
            }
        }

        [HttpPut(Name = "AtualizarConta")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> PutConta(Conta conta)
        {
            Operacoes operacao = new Operacoes();

            var atualizou = await operacao.AtualizarConta(conta);
            if (atualizou)
            {
                return Ok($"Conta {conta.idConta} nome {conta.nome}, atualizada com sucesso");
            }
            else
            {
                return BadRequest($"Não foi possível atualizar a conta {conta.idConta}");
            }
        }

        [HttpDelete(Name = "DeletarConta")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> DeleteConta(Conta conta)
        {
            Operacoes operacao = new Operacoes();

            var contaDeletada = await operacao.DeletarConta(conta);
            if (contaDeletada.idConta != 0)
            {
                return Ok($"Conta {contaDeletada.idConta} nome {contaDeletada.nome}, apagada com sucesso");
            }
            else
            {
                return BadRequest($"Não foi possível apagar a conta {conta.idConta}");
            }
        }
    }
}