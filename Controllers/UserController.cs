using Microsoft.AspNetCore.Mvc;
using WoofHub_App.Data;
using WoofHub_App.Models;

namespace WoofHub_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private WoofHubContext _context;

        public UserController(WoofHubContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> AddUser(UserModel user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return Created("", user);
        }


        [HttpGet]
        public IEnumerable<UserModel> ShowAllUsers()
        {
            return _context.User;
        }

        [HttpGet("Search")]
        public IActionResult SearchUserName([FromQuery] string UserName)
        {
            var matchingUsers = _context.User.Where(user => user.UserName == UserName).ToList();
            if (!matchingUsers.Any())
                return NotFound();

            return Ok(matchingUsers);
        }
    }
}