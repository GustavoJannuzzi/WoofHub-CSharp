using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WoofHub_App.Data;
using WoofHub_App.Data.Dtos;
using WoofHub_App.Data.Dtos.UserDtos;
using WoofHub_App.Models;

namespace WoofHub_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private WoofHubContext _context;
        private IMapper _mapper;

        public UserController(WoofHubContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> AddUser([FromBody] CreateUserDto userDto)
        {
            UserModel user = _mapper.Map<UserModel>(userDto);

            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();

            return Created("", user);
        }


        [HttpGet]
        public IEnumerable<UserModel> ShowAllUsers()
        {
            return _context.User;
        }

        [HttpGet("{id}")]
        public IActionResult SearchUserId(int id)
        {
            var user = _context.User.FirstOrDefault(user => user.Id == id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UpdateUserDto userDto)
        {
            var user = _context.User.FirstOrDefault(
                user => user.Id == id);
            if (user == null)
                return NotFound();
            _mapper.Map(userDto, user);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateUserPatch(int id, JsonPatchDocument<UpdateUserDto> patch)
        {
            var user = _context.User.FirstOrDefault(
                user => user.Id == id);
            if (user == null)
                return NotFound();

            var userUpdate = _mapper.Map<UpdateUserDto>(user);

            patch.ApplyTo(userUpdate, ModelState);

            if (!TryValidateModel(userUpdate))
                return ValidationProblem(ModelState);

            _mapper.Map(userUpdate, user);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.User.FirstOrDefault(
                user => user.Id == id);
            if (user == null)
                return NotFound();
            _context.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }
    }
}