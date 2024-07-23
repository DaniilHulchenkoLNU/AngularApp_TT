using AngularApp_TT.Server.Models.Auth;
using DAL.Interfaces;

namespace AngularApp_TT.Server.DAL.Interfaces
{
    public interface iUserRepository : iBaseRepository<Accounts, int>
    {
        public Task<Accounts> FindUserAuth(string email, string password);
    }
}
