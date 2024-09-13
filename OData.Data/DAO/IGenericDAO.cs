using OData.Data.Models;

namespace OData.Data.DAO
{
    public interface IGenericDAO<T> where T : class
    {
        IEnumerable<T> GetAll();
    }
}
