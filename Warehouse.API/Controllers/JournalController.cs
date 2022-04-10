using Microsoft.AspNetCore.Mvc;

namespace Warehouse.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JournalController : ControllerBase
    {
        private readonly ILogger<JournalController> _logger;

        public JournalController(ILogger<JournalController> logger)
        {
            _logger = logger;
        }
    }
}
