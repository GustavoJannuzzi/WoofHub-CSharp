using Microsoft.AspNetCore.Mvc;
using WoofHub_App.Data;
using WoofHub_App.Models;

namespace WoofHub_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private WoofHubContext _context;

        public ClientController(WoofHubContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<ClientModel>> Insert(ClientModel client)
        {
            if (!ClientModel.IsCpf(client.ClientCpf))
                return BadRequest("CPF inválido");

            _context.Client.Add(client);
            await _context.SaveChangesAsync();

            return Created("", client);
        }


        [HttpGet]
        public IEnumerable<ClientModel> ShowAllClients()
        {
            return _context.Client;
        }

        [HttpGet]
        [Route("{cpf}")]
        public async Task<ActionResult<ClientModel>> SearchCpf([FromRoute] string cpf)
        {
            if (_context.Client is null)
                return NotFound();
            var client = await _context.Client.FindAsync(cpf);
            if (client is null)
                return NotFound();
            return client;
        }
    }
}