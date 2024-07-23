using AngularApp_TT.Server.Models.Auth;
using AngularApp_TT.Server.Models.Entity;
using DAL.Interfaces;
using AngularApp_TT.Server.Servise.Auth;
using Microsoft.AspNetCore.Mvc;

namespace AngularApp_TT.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase // Tokens
    {
        private readonly AuthServise authServise;
        private readonly iBaseRepository<Accounts, int> loginrepisitory;

        public AuthController(AuthServise authServise, iBaseRepository<Accounts, int> loginrepisitory)
        {
            this.loginrepisitory = loginrepisitory;
            this.authServise = authServise;
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login request)
        {
            var user = await authServise.AuthentificateUser(request.Email, request.Password);
            if (user != null)
            {
                var token = authServise.GenerateJWT(user);
                return Ok(new { access_token = token });
            }
            return Unauthorized();
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] Login request)
        {
            Accounts accounts = new Accounts
            {
                Email = request.Email,
                Password = request.Password,
                UserHistoryList = new List<СryptoRate>(),
            };
            //await loginrepisitory.Create(accounts);
            await authServise.RegisterUser(accounts);
            return Ok();
        }

    }
}
