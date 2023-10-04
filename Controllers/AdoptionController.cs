using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WoofHub_App.Data;
using WoofHub_App.Data.Dtos.AdoptionDto;
using WoofHub_App.Models;

namespace WoofHub_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdoptionController : ControllerBase
    {
        private WoofHubContext _context;
        private IMapper _mapper;
        public AdoptionController(WoofHubContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<AdoptionModel>> AddAdoption([FromBody] CreateAdoptionDto adoptionDto)
        {
            AdoptionModel adoption = _mapper.Map<AdoptionModel>(adoptionDto);
            await _context.Adoption.AddAsync(adoption);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(SearchAdoptionId),
                new{ Id = adoption.Id }, adoption);
        }

        [HttpGet]
         public async Task<IEnumerable<ReadAdoptionDto>> ShowAllAdoptions()
        {
            var adoptions = await _context.Adoption.ToListAsync();
            return _mapper.Map<List<ReadAdoptionDto>>(adoptions);
        }

        [HttpGet("{id}")]
        public IActionResult SearchAdoptionId(int id)
        {
            var adoption = _context.Adoption.FirstOrDefault(adoption => adoption.Id == id);
            if (adoption == null)
                return NotFound();
            return Ok(adoption);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdoption(int id, [FromBody] UpdateAdoptionDto adoptionDto)
        {
            var adoption = _context.Adoption.FirstOrDefault(
                adoption => adoption.Id == id);
            if (adoption == null)
                return NotFound();
            _mapper.Map(adoptionDto, adoption);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateEventPatch(int id, JsonPatchDocument<UpdateAdoptionDto> patch)
        {
            var adoption = _context.Adoption.FirstOrDefault(
                adoption => adoption.Id == id);
            if (adoption == null)
                return NotFound();

            var adoptionUpdate = _mapper.Map<UpdateAdoptionDto>(adoption);

            patch.ApplyTo(adoptionUpdate, ModelState);

            if (!TryValidateModel(adoptionUpdate))
                return ValidationProblem(ModelState);
              
            _mapper.Map(adoptionUpdate, adoption);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deleteevent(int id)
        {
            var adoption = _context.Adoption.FirstOrDefault(
                adoption => adoption.Id == id);
            if (adoption == null)
                return NotFound();
            _context.Remove(adoption);
            _context.SaveChanges();
            return NoContent();
        }
    }
}