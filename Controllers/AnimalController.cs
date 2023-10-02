using Microsoft.AspNetCore.Mvc;
using WoofHub_App.Data;
using WoofHub_App.Models;

namespace WoofHub_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalController : ControllerBase
    {
        private WoofHubContext _context;
        public AnimalController(WoofHubContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddAnimal([FromBody] AnimalModel animal)
        {
            _context.Animal.Add(animal);
            _context.SaveChanges();
            return CreatedAtAction(nameof(SearchAnimalId),
                new { id = animal.Id },
                animal);
        }

        [HttpGet]
        public IEnumerable<AnimalModel> ShowAllAnimals()
        {
            return _context.Animal;
        }

        [HttpGet("{id}")]
        public IActionResult SearchAnimalId(int id)
        {
            var animal = _context.Animal.FirstOrDefault(animal => animal.Id == id);
            if (animal == null)
                return NotFound();

            return Ok(animal);
        }

        [HttpGet("Search")]
        public IActionResult SearchAnimalName([FromQuery] string AnimalName)
        {
            var matchingAnimals = _context.Animal.Where(animal => animal.AnimalName == AnimalName).ToList();
            if (!matchingAnimals.Any())
                return NotFound();

            return Ok(matchingAnimals);
        }
    }
}