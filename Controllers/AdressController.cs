using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WoofHub_App.Data;
using WoofHub_App.Data.Dtos.AdressDto;
using WoofHub_App.Models;

namespace WoofHub_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdressController : ControllerBase
    {
        private WoofHubContext _context;
        private IMapper _mapper;

        public AdressController(WoofHubContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<AdressModel>> AddAdress([FromBody] CreateAdressDto adressDto)
        {
            AdressModel adress = _mapper.Map<AdressModel>(adressDto);

            await _context.Adress.AddAsync(adress);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(SearchAdressId), new { Id = adress.Id},
                adressDto);
        }

        [HttpGet]
        public async Task<IEnumerable<ReadAdressDto>> ShowAllAdresses()
        {
            var adresses = await _context.Adress.ToListAsync();
            return _mapper.Map<List<ReadAdressDto>>(adresses);
        }

        [HttpGet("{id}")]
        public IActionResult SearchAdressId(int id)
        {
            var adress = _context.Adress.FirstOrDefault(adress => adress.Id == id);
            if (adress == null)
                return NotFound();
            return Ok(adress);
        }

        // [HttpGet("Search")]
        // public IActionResult SearchClientCpf([FromQuery] string ClientCpf)
        // {
        //     var matchClient = _context.Client.SingleOrDefault(client => client.ClientCpf == ClientCpf);
        //     if (matchClient == null)
        //         return NotFound();

        //     return Ok(matchClient);
        // }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdress(int id, [FromBody] UpdateAdressDto adressDto)
        {
            var adress = _context.Adress.FirstOrDefault(
                adress => adress.Id == id);
            if (adress == null)
                return NotFound();
            _mapper.Map(adressDto, adress);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAdressPatch(int id, JsonPatchDocument<UpdateAdressDto> patch)
        {
            var adress = _context.Adress.FirstOrDefault(
                adress => adress.Id == id);
            if (adress == null)
                return NotFound();

            var adressUpdate = _mapper.Map<UpdateAdressDto>(adress);

            patch.ApplyTo(adressUpdate, ModelState);

            if (!TryValidateModel(adressUpdate))
                return ValidationProblem(ModelState);
              
            _mapper.Map(adressUpdate, adress);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAdress(int id)
        {
            var adress = _context.Adress.FirstOrDefault(
                adress => adress.Id == id);
            if (adress == null)
                return NotFound();
            _context.Remove(adress);
            _context.SaveChanges();
            return NoContent();
        }
    }
}