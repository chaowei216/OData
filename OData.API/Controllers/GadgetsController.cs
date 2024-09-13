using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using OData.Service;

namespace OData.API.Controllers
{
    [Route("gadgets")]
    [ApiController]
    public class GadgetsController : ControllerBase
    {
        private readonly IGadgetService _service;

        public GadgetsController(IGadgetService service)
        {
            _service = service;
        }

        // supports OData query options
        [EnableQuery]
        [HttpGet("Get")]
        public IActionResult Get()
        {
            return Ok(_service.GetGadgets());
        }
    }
}
