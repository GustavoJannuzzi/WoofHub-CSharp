using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WoofHub_App.Data;
using WoofHub_App.Data.Dtos.AbandonmentReportDto;
using WoofHub_App.Models;

namespace WoofHub_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AbandonmentReportController : ControllerBase
    {
        private WoofHubContext _context;
        private IMapper _mapper;

        public AbandonmentReportController(WoofHubContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<AbandonmentReportModel>> AddReport([FromBody] CreateAbandonmentReportDto reportDto)
        {
            AbandonmentReportModel report = _mapper.Map<AbandonmentReportModel>(reportDto);

            _context.AbandonmentReport.Add(report);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(SearchReportId), new { Id = report.Id},
                reportDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AbandonmentReportModel>>> ShowReports()
        {
            if(_context.AbandonmentReport is null)
                return NotFound();
            return await _context.AbandonmentReport.ToListAsync();
        }

        [HttpGet("{id}")]
        public IActionResult SearchReportId(int id)
        {
            var report = _context.AbandonmentReport.FirstOrDefault(report => report.Id == id);
            if (report == null)
                return NotFound();
            return Ok(report);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReport(int id)
        {
            var report = _context.AbandonmentReport.FirstOrDefault(
                report => report.Id == id);
            if (report == null)
                return NotFound();
            _context.Remove(report);
            _context.SaveChanges();
            return NoContent();
        }
    }
}