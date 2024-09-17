using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using OData.Service;

namespace OData.API.Controllers
{
    public class GadgetsOdataController : ControllerBase
    {
        private readonly IGadgetService _service;

        public GadgetsOdataController(IGadgetService service)
        {
            _service = service;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_service.GetGadgets());   
        }
    }
}
