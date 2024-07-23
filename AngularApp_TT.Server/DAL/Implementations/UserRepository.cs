using AngularApp_TT.Data;
using AngularApp_TT.Server.Models.Auth;
using DAL.Implementations;
using AngularApp_TT.Server.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AngularApp_TT.Server.DAL.Implementations
{
    public class UserRepository : BaseRepository<Accounts>, iUserRepository
    {
        private readonly DbSet<Accounts> _data;
        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _data = db.Set<Accounts>();
        }
        public async Task<Accounts> FindUserAuth(string email, string password)
        {
            return await _data.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        }
    }
}
