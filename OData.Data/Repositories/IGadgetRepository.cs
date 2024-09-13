using OData.Data.Models;

namespace OData.Data.Repositories
{
    public interface IGadgetRepository
    {
        IEnumerable<Gadget> GetGadgets();
    }
}
