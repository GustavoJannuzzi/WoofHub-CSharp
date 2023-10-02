using Microsoft.AspNetCore.Mvc;
using WoofHub_App.Data;
using WoofHub_App.Models;

namespace WoofHub_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonationController : ControllerBase
    {
        private WoofHubContext _context;
        public DonationController(WoofHubContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddDonation([FromBody] DonationModel donation)
        {
            _context.Donation.Add(donation);
            _context.SaveChanges();
            return CreatedAtAction(nameof(SearchDonationId),
                new { id = donation.Id },
                donation);
        }

        [HttpGet]
        public IEnumerable<DonationModel> ShowAllDonations()
        {
            return _context.Donation;
        }

        [HttpGet("{id}")]
        public IActionResult SearchDonationId(int id)
        {
            var donation = _context.Donation.FirstOrDefault(donation => donation.Id == id);
            if (donation == null)
                return NotFound();

            return Ok(donation);
        }
    }
}