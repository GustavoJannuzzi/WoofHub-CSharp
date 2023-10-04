using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WoofHub_App.Data;
using WoofHub_App.Data.Dtos;
using WoofHub_App.Data.Dtos.AnimalDtos;
using WoofHub_App.Models;

namespace WoofHub_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalController : ControllerBase
    {
        private WoofHubContext _context;
        private IMapper _mapper;

        public AnimalController(WoofHubContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<AnimalModel>> AddAnimal([FromBody] CreateAnimalDto animalDto)
        {
            AnimalModel animal = _mapper.Map<AnimalModel>(animalDto);

            await _context.Animal.AddAsync(animal);
            await _context.SaveChangesAsync();
            return Created("", animal);
        }

        [HttpGet]
        public async Task<IEnumerable<ReadAnimalDto>> ShowAllAnimals()
        {
            var animals = await _context.Animal.ToListAsync();
            return _mapper.Map<List<ReadAnimalDto>>(animals);
        }

        [HttpGet("{id}")]
        public IActionResult SearchAnimalId(int id)
        {
            var animal = _context.Animal.FirstOrDefault(animal => animal.Id == id);
            if (animal == null)
                return NotFound();
            var animalDto = _mapper.Map<ReadAnimalDto>(animal);
            return Ok(animalDto);
        }

        [HttpGet("Search")]
        public IActionResult SearchAnimalName([FromQuery] string AnimalName)
        {
            var matchingAnimals = _context.Animal.Where(animal => animal.AnimalName == AnimalName).ToList();
            if (!matchingAnimals.Any())
                return NotFound();

            return Ok(matchingAnimals);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAnimal(int id, [FromBody] UpdateAnimalDto animalDto)
        {
            var animal = _context.Animal.FirstOrDefault(
                animal => animal.Id == id);
            if (animal == null)
                return NotFound();
            _mapper.Map(animalDto, animal);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateAnimalPatch(int id, JsonPatchDocument<UpdateAnimalDto> patch)
        {
            var animal = _context.Animal.FirstOrDefault(
                animal => animal.Id == id);
            if (animal == null)
                return NotFound();

            var animalUpdate = _mapper.Map<UpdateAnimalDto>(animal);

            patch.ApplyTo(animalUpdate, ModelState);

            if (!TryValidateModel(animalUpdate))
                return ValidationProblem(ModelState);

            _mapper.Map(animalUpdate, animal);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            var animal = _context.Animal.FirstOrDefault(
                animal => animal.Id == id);
            if (animal == null)
                return NotFound();
            _context.Remove(animal);
            _context.SaveChanges();
            return NoContent();
        }
    }
}