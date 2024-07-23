using AngularApp_TT.Server.DAL.Interfaces;
using AngularApp_TT.Server.Models.Auth;
using System.Security.Claims;

namespace AngularApp_TT.Server.Servise.Helpers
{
    public class HttpService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public iUserRepository userRepository { get; }

        public HttpService(IHttpContextAccessor httpContextAccessor, iUserRepository userRepository)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.userRepository = userRepository;
        }

        public int GetCurrentUserId()
        {
            //var userIdClaim = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            //return userIdClaim?.Value;
            var claims = httpContextAccessor.HttpContext.User.Claims;

            //var subClaim = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub);
            var subClaim = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            string userId = subClaim?.Value;
            return Convert.ToInt32(userId);
        }

        public async Task<Accounts> GetCurrentUser()
        {
            return await userRepository.GetValueByID(GetCurrentUserId());
        }
    }
}
