using Microsoft.AspNetCore.Mvc;
using WoofHub_App.Data;
using WoofHub_App.Models;

namespace WoofHub_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AbandonmentReportController : ControllerBase
    {
        private WoofHubContext _context;
        public AbandonmentReportController(WoofHubContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddAbandonmentReport([FromBody] AbandonmentReportModel abandonment)
        {
            _context.AbandonmentReport.Add(abandonment);
            _context.SaveChanges();
            return CreatedAtAction(nameof(SearchAbandonmentReportId),
                new { id = abandonment.Id },
                abandonment);
        }

        [HttpGet]
        public IEnumerable<AbandonmentReportModel> ShowAllAbandonmentReport()
        {
            return (IEnumerable<AbandonmentReportModel>)_context.AbandonmentReport;
        }

        [HttpGet("{id}")]
        public IActionResult SearchAbandonmentReportId(int id)
        {
            var abandonment = _context.AbandonmentReport.FirstOrDefault(abandonment => abandonment.Id == id);
            if (abandonment == null)
                return NotFound();

            return Ok(abandonment);
        }

    }
}