using AngularApp_TT.Server.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using AngularApp_TT.Data;
using Microsoft.OpenApi.Any;




namespace DAL.Implementations
{
    public class BaseRepository<T, tId> : iBaseRepository<T, tId> where T : DbBase<tId>
    {
        private readonly ApplicationDbContext _db;

        public BaseRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public virtual async Task<bool> Create(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;

        }

        public async Task<bool> Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _db.Set<T>().ToArrayAsync();

        }

        public virtual IQueryable<T> GetALL()
        {
            return _db.Set<T>();
        }

        public async Task<T> GetValueByID(tId id)
        {
            return await _db.Set<T>().FindAsync(id);
        }


        public async Task<bool> Update(T entity)
        {
            _db.Set<T>().Update(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
