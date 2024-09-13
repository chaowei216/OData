using OData.Data.DAO;
using OData.Data.Models;

namespace OData.Data.Repositories
{
    public class GadgetRepository : IGadgetRepository
    {
        private IGenericDAO<Gadget> _gadgetDAO;

        public GadgetRepository(IGenericDAO<Gadget> gadgetDAO)
        {
            _gadgetDAO = gadgetDAO;
        }

        public IEnumerable<Gadget> GetGadgets()
        {
            return _gadgetDAO.GetAll();
        }
    }
}
