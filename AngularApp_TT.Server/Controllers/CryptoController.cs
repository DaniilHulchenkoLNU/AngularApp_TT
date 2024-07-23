using AngularApp_TT.Server.Models.Auth;
using AngularApp_TT.Server.Models.Entity;
using AngularApp_TT.Server.Services;
using DAL.Interfaces;
using GlassStore.Server.Servise.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AngularApp_TT.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize]
    public class CryptoController : ControllerBase
    {

        private readonly CryptoService _cryptoService;
        private readonly iBaseRepository<СryptoRate, string> ctyptorepository;
        private readonly UserServise userServise;

        public CryptoController(CryptoService cryptoService, iBaseRepository<СryptoRate, string> ctyptorepository, UserServise userServise)
        {
            _cryptoService = cryptoService;
            this.ctyptorepository = ctyptorepository;
            this.userServise = userServise;
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
        public async Task<ActionResult> Save([FromBody] СryptoRate rate)
        {
            rate.id = null;
            rate.Accounts = await userServise.GetUser();
            await ctyptorepository.Create(rate);
            return Ok();
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
