using OData.Data.Models;

namespace OData.Service
{
    public interface IGadgetService
    {
        IEnumerable<Gadget> GetGadgets();
    }
}
