using Microsoft.AspNetCore.Mvc;
using WoofHub_App.Data;
using WoofHub_App.Models;

namespace WoofHub_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private WoofHubContext _context;
        public EventController(WoofHubContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddEvent([FromBody] EventModel eventWoof)
        {
            _context.Event.Add(eventWoof);
            _context.SaveChanges();
            return CreatedAtAction(nameof(SearchEventId),
                new { id = eventWoof.Id },
                eventWoof);
        }

        [HttpGet]
        public IEnumerable<EventModel> ShowAllEvents()
        {
            return _context.Event;
        }

        [HttpGet("{id}")]
        public IActionResult SearchEventId(int id)
        {
            var eventWoof = _context.Event.FirstOrDefault(eventWoof => eventWoof.Id == id);
            if (eventWoof == null)
                return NotFound();

            return Ok(eventWoof);
        }

        [HttpGet("Search")]
        public IActionResult SearchENameEvent([FromQuery] string NameEvent)
        {
            var matchingEvents = _context.Event.Where(eventWoof => eventWoof.NameEvent == NameEvent).ToList();
            if (!matchingEvents.Any())
                return NotFound();

            return Ok(matchingEvents);
        }
    }
}