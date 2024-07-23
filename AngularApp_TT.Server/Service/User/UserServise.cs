


using AngularApp_TT.Server.DAL.Interfaces;
using AngularApp_TT.Server.Models.Auth;
using AngularApp_TT.Server.Servise.Helpers;

namespace GlassStore.Server.Servise.User
{
    public class UserServise
    {
        private readonly iUserRepository _userRepository;
        private readonly HttpService httpService;

        public UserServise(iUserRepository userRepository, HttpService httpService)
        {
            _userRepository = userRepository;
            this.httpService = httpService;

        }

        public async Task<Accounts> GetUserbyId(int id)
        {
            Accounts account = await _userRepository.GetValueByID(id);
            return account;
        }

        public async Task<Accounts> GetUser()
        {
            Accounts account = await httpService.GetCurrentUser();
            return account;
        }



    }
}
