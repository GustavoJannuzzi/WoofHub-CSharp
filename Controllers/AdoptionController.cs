using Microsoft.AspNetCore.Mvc;
using WoofHub_App.Data;
using WoofHub_App.Models;

namespace WoofHub_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdoptionController : ControllerBase
    {
        private WoofHubContext _context;
        public AdoptionController(WoofHubContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddAdoption([FromBody] AdoptionModel adoption)
        {
            _context.Adoption.Add(adoption);
            _context.SaveChanges();
            return CreatedAtAction(nameof(SearchAdoptionId),
                new { id = adoption.Id },
                adoption);
        }

        [HttpGet]
        public IEnumerable<AdoptionModel> ShowAllAdoptions()
        {
            return _context.Adoption;
        }

        [HttpGet("{id}")]
        public IActionResult SearchAdoptionId(int id)
        {
            var adoption = _context.Adoption.FirstOrDefault(adoption => adoption.Id == id);
            if (adoption == null)
                return NotFound();

            return Ok(adoption);
        }
    }
}