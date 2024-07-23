
using Microsoft.OpenApi.Any;

namespace DAL.Interfaces
{
    public interface iBaseRepository<T, tId> where T : class
    {
        public Task<bool> Create(T entity);
        public Task<bool> Delete(T entity);
        public Task<T> GetValueByID(tId id);
        public Task<IEnumerable<T>> GetAll();
        public IQueryable<T> GetALL();
    }
}
