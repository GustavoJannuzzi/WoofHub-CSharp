using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WoofHub_App.Data;
using WoofHub_App.Data.Dtos;
using WoofHub_App.Data.Dtos.DonationDtos;
using WoofHub_App.Models;

namespace WoofHub_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonationController : ControllerBase
    {
        private WoofHubContext _context;
        private IMapper _mapper;

        public DonationController(WoofHubContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<DonationModel>> AddDonation([FromBody] CreateDonationdto donationDto)
        {
            DonationModel donation = _mapper.Map<DonationModel>(donationDto);

            await _context.Donation.AddAsync(donation);
            await _context.SaveChangesAsync();
            return Created("", donation);
        }

        [HttpGet]
        public async Task<IEnumerable<DonationModel>> ShowDonations()
        {
            return await _context.Donation.ToArrayAsync();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDonation(int id, [FromBody] UpdateDonationDto donationDto)
        {
            var donation = _context.Donation.FirstOrDefault(
                donation => donation.Id == id);
            if (donation == null)
                return NotFound();
            _mapper.Map(donationDto, donation);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateDonationPatch(int id, JsonPatchDocument<UpdateDonationDto> patch)
        {
            var donation = _context.Donation.FirstOrDefault(
                donation => donation.Id == id);
            if (donation == null)
                return NotFound();

            var donationUpdate = _mapper.Map<UpdateDonationDto>(donation);

            patch.ApplyTo(donationUpdate, ModelState);

            if (!TryValidateModel(donationUpdate))
                return ValidationProblem(ModelState);

            _mapper.Map(donationUpdate, donation);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDonation(int id)
        {
            var donation = _context.Donation.FirstOrDefault(
                donation => donation.Id == id);
            if (donation == null)
                return NotFound();
            _context.Remove(donation);
            _context.SaveChanges();
            return NoContent();
        }
    }
}