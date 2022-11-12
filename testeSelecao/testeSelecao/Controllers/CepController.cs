using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace testeSelecao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CepController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CepController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet(Name = "GetCep")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> GetCep()
        {
            try
            {
                var urlApi = _configuration.GetSection("LinkApiCep").Value;
                var client = new RestClient(urlApi);
                var request = new RestRequest(urlApi, (Method)DataFormat.Json);
                var response = await client.GetAsync(request);

                if (response.IsSuccessful)
                {
                    return Ok(response.Content);
                }
                else
                {
                    return BadRequest($"Falha ao consultar CEP, código {response.StatusCode}, descrição do status {response.StatusDescription}");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Falha na conexão com a API de CEP: {ex.Message} \n {ex.StackTrace}");
            }
        }
    }
}