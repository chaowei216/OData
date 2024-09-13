
using Microsoft.EntityFrameworkCore;
using OData.Data.DataContext;

namespace OData.Data.DAO
{
    public class GenericDAO<T> : IGenericDAO<T> where T : class
    {
        private ODataDbContext _context;
        private DbSet<T> _dbSet;

        public GenericDAO()
        {
            _context = new ODataDbContext();
            _dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }
    }
}
