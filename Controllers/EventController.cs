using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WoofHub_App.Data;
using WoofHub_App.Data.Dtos;
using WoofHub_App.Models;
using WoofHub_App.Data.Dtos.EventDtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;


namespace WoofHub_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private WoofHubContext _context;
        private IMapper _mapper;

        public EventController(WoofHubContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<EventModel>> AddEvent([FromBody] CreateEventDto eventDto)
        {
            EventModel eventAdoption = _mapper.Map<EventModel>(eventDto);
            await _context.Event.AddAsync(eventAdoption);
            await _context.SaveChangesAsync();

            return Created("", eventAdoption);
        }

        [HttpGet]
         public async Task<IEnumerable<ReadEventDto>> ShowAllEvents()
        {
            var events = await _context.Event.ToListAsync();
            return _mapper.Map<List<ReadEventDto>>(events);
        }

        [HttpGet("{id}")]
        public IActionResult SearchEventId(int id)
        {
            var eventAdoption = _context.Event.FirstOrDefault(eventAdoption => eventAdoption.Id == id);
            if (eventAdoption == null)
                return NotFound();
            return Ok(eventAdoption);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, [FromBody] UpdateEventDto eventDto)
        {
            var eventAdoption = _context.Event.FirstOrDefault(
                eventAdoption => eventAdoption.Id == id);
            if (eventAdoption == null)
                return NotFound();
            _mapper.Map(eventDto, eventAdoption);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateEventPatch(int id, JsonPatchDocument<UpdateEventDto> patch)
        {
            var eventAdoption = _context.Event.FirstOrDefault(
                eventAdoption => eventAdoption.Id == id);
            if (eventAdoption == null)
                return NotFound();

            var eventUpdate = _mapper.Map<UpdateEventDto>(eventAdoption);

            patch.ApplyTo(eventUpdate, ModelState);

            if (!TryValidateModel(eventUpdate))
                return ValidationProblem(ModelState);
              
            _mapper.Map(eventUpdate, eventAdoption);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deleteevent(int id)
        {
            var eventAdoption = _context.Event.FirstOrDefault(
                eventAdoption => eventAdoption.Id == id);
            if (eventAdoption == null)
                return NotFound();
            _context.Remove(eventAdoption);
            _context.SaveChanges();
            return NoContent();
        }
    }
}