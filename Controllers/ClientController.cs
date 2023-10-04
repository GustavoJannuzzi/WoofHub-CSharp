using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WoofHub_App.Data;
using WoofHub_App.Data.Dtos;
using WoofHub_App.Data.Dtos.ClientDtos;
using WoofHub_App.Models;

namespace WoofHub_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private WoofHubContext _context;
        private IMapper _mapper;

        public ClientController(WoofHubContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<ClientModel>> AddClient([FromBody] CreateClientDto clientDto)
        {
            ClientModel client = _mapper.Map<ClientModel>(clientDto);

            if (!ClientModel.IsCpf(client.ClientCpf))
                return BadRequest("CPF inválido");

            await _context.Client.AddAsync(client);
            await _context.SaveChangesAsync();

            return Created("", client);
        }

        [HttpGet]
         public async Task<IEnumerable<ReadClientDto>> ShowAllClients()
        {
            var clients = await _context.Client.ToListAsync();
            return _mapper.Map<List<ReadClientDto>>(clients);
        }
        
        [HttpGet("{id}")]
        public IActionResult SearchClientId(int id)
        {
            var client = _context.Client.FirstOrDefault(client => client.Id == id);
            if (client == null)
                return NotFound();
            return Ok(client);
        }

        [HttpGet("Search")]
        public IActionResult SearchClientCpf([FromQuery] string ClientCpf)
        {
            var matchClient = _context.Client.SingleOrDefault(client => client.ClientCpf == ClientCpf);
            if (matchClient == null)
                return NotFound();

            return Ok(matchClient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, [FromBody] UpdateClientDto clientDto)
        {
            var client = _context.Client.FirstOrDefault(
                client => client.Id == id);
            if (client == null)
                return NotFound();
            _mapper.Map(clientDto, client);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateClientPatch(int id, JsonPatchDocument<UpdateClientDto> patch)
        {
            var client = _context.Client.FirstOrDefault(
                client => client.Id == id);
            if (client == null)
                return NotFound();

            var clientUpdate = _mapper.Map<UpdateClientDto>(client);

            patch.ApplyTo(clientUpdate, ModelState);

            if (!TryValidateModel(clientUpdate))
                return ValidationProblem(ModelState);
              
            _mapper.Map(clientUpdate, client);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            var client = _context.Client.FirstOrDefault(
                client => client.Id == id);
            if (client == null)
                return NotFound();
            _context.Remove(client);
            _context.SaveChanges();
            return NoContent();
        }
    }
}