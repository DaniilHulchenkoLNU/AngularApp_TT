using AngularApp_TT.Server.Models.Entity;
using AngularApp_TT.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AngularApp_TT.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CryptoController : ControllerBase
    {

        private readonly CryptoService _cryptoService;

        public CryptoController(CryptoService cryptoService)
        {
            _cryptoService = cryptoService;
        }

        // GET: api/<CryptoController>
        [HttpGet]
        public async Task<ActionResult<List<СryptoRate>>> Get()
        {
            try
            {
                var cryptoRates = await _cryptoService.FetchCryptoRatesAsync();
                if (cryptoRates == null || cryptoRates.Count == 0)
                {
                    return NotFound("No cryptocurrency data found.");
                }

                return Ok(cryptoRates);
            }
            catch (Exception ex)
            {
                // Логирование ошибки или другие действия
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet("test")]
        public bool test()
        {
            return true;
        }

        [HttpPost("Save")]
        public void Save([FromBody] СryptoRate rate)
        {

        }

        // GET api/<CryptoController>/5
        [HttpGet("{id}")]
        public СryptoRate Get(int id)
        {
            throw new NotImplementedException();
        }

        // PUT api/<CryptoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] СryptoRate value)
        {
        }

        // DELETE api/<CryptoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
