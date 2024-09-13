using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using OData.Service;

namespace OData.API.Controllers
{
    [Route("GadgetsOdata")]
    [ApiController]
    public class GadgetsOdataController : ControllerBase
    {
        private readonly IGadgetService _service;

        public GadgetsOdataController(IGadgetService service)
        {
            _service = service;
        }

        [EnableQuery]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetGadgets());
        }
    }
}
