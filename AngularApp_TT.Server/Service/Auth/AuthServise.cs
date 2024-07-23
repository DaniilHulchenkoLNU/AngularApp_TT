using AngularApp_TT.Server.Models.Auth;
using AngularApp_TT.Server.DAL.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AngularApp_TT.Server.Models.Entity;
using Azure.Core;
using DAL.Interfaces;

namespace AngularApp_TT.Server.Servise.Auth
{
    public class AuthServise
    {
        private readonly IOptions<AuthOptions> authoptions;
        private readonly iBaseRepository<Accounts, int> accountsRepository;
        private readonly iUserRepository authRepository;
        public AuthServise(iUserRepository authRepository, IOptions<AuthOptions> authOptions, iBaseRepository<Accounts, int> AccountsRepository)
        {
            this.authoptions = authOptions;
            accountsRepository = AccountsRepository;
            this.authRepository = authRepository;
        }
        public async Task<Accounts> AuthentificateUser(string email, string password)
        {
            // дописати роз-хешуваня пароля
            return await authRepository.FindUserAuth(email, password);
        }
        public async Task<Accounts> RegisterUser(Accounts accounts)
        {
            // дописати хешуваня пароля
            await accountsRepository.Create(accounts);
            return accounts;
        }

        public string GenerateJWT(Accounts user)
        {
            var authParams = authoptions.Value;
            var securityKey = authParams.GetSymmetricSecurityKey();

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>() {
                        //new Claim (JwtRegisteredClaimNames.NameId, user.Id),
                        new Claim(JwtRegisteredClaimNames.Sub, user.id.ToString()),
                        new Claim (JwtRegisteredClaimNames.Email, user.Email),

                    };

            var token = new JwtSecurityToken(authParams.Issuer,
            authParams.Audience,
            claims,
            expires: DateTime.Now.AddSeconds(authParams.TokenLifetime),
            signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }



    }
}
