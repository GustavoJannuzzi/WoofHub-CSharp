using Microsoft.AspNetCore.Mvc;
using WoofHub_App.Data;
using WoofHub_App.Models;

namespace WoofHub_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdressController : ControllerBase
    {
        private WoofHubContext _context;
        public AdressController(WoofHubContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddAdress([FromBody] AdressModel adress)
        {
            _context.Adress.Add(adress);
            _context.SaveChanges();
            return CreatedAtAction(nameof(SearchAdressId),
                new { id = adress.Id },
                adress);
        }

        [HttpGet]
        public IEnumerable<AdressModel> ShowAllAdress()
        {
            return _context.Adress;
        }

        [HttpGet("{id}")]
        public IActionResult SearchAdressId(int id)
        {
            var adress = _context.Adress.FirstOrDefault(adress => adress.Id == id);
            if (adress == null)
                return NotFound();

            return Ok(adress);
        }
    }
}