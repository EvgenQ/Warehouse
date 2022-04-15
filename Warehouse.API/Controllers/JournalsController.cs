using Microsoft.AspNetCore.Mvc;
using Warehouse.API.Contracts;
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

            int journalId = JournalsRepository.Add(journal);

            return Ok(journalId);
        }

        [HttpPost("{journalId:int}/products")]
        public async Task<IActionResult> AddProduct([FromRoute]int journalId, AddProductsRequest request)
        {
            var journal = JournalsRepository.Get(journalId);
            if (journal is null)
            {
                return NotFound($"Журнал с id - {journalId} не найден");
            }

            journal.AddProduct(request.ProductIds);

            JournalsRepository.Update(journal);

            return Ok(journal);
        }
    }
}
