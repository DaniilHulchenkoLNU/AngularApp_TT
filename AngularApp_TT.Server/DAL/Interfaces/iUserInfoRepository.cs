using TT_Auth.Models.Entity;

namespace DAL.Interfaces
{
    public interface iUserInfoRepository
    {
        public UserInfo FindUserAuth(string email, string password);
        public UserInfo FindUserByEmail(string email);
        public Task<bool> Create(UserInfo entity);
        public bool Update(UserInfo userInfo);
    }
}
