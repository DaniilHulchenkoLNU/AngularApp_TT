
namespace DAL.Interfaces
{
    public interface iBaseRepository<T> where T : class
    {
        public Task<bool> Create(T entity);
        public Task<bool> Delete(T entity);
        public Task<T> GetValueByID(int id);
        public Task<IEnumerable<T>> GetAll();
        public IQueryable<T> GetALL();
    }
}
