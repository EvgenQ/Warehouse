using Microsoft.AspNetCore.Mvc;
using Warehouse.Domain;

namespace Warehouse.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JournalsController : ControllerBase
    {
        private readonly ILogger<JournalsController> _logger;

        public JournalsController(ILogger<JournalsController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateJournalRequest request)
        {
            var (journal, errors) = Journal.Create(request.CreatedDate);

            if (journal is null || errors.Any())
            {
                _logger.LogError("{errors}", errors);
                return BadRequest(errors);
            }

            return Ok(journal);
        }
    }
}
