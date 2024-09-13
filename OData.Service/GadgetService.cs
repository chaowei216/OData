using OData.Data.Models;
using OData.Data.Repositories;

namespace OData.Service
{
    public class GadgetService : IGadgetService
    {
        private readonly IGadgetRepository _repo;

        public GadgetService(IGadgetRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Gadget> GetGadgets()
        {
            return _repo.GetGadgets();
        }
    }
}
