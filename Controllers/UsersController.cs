using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPITutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return Ok(await _context.Users.ToListAsync());
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<User>> Get(int ID)
        {
            var User = await _context.Users.FindAsync(ID);
            if (User == null)
                return BadRequest("User not found.");

            return Ok(User);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> Add(User User)
        {
            _context.Users.Add(User);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Users.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<User>> Update(User updatedUser)
        {
            var User = await _context.Users.FindAsync(updatedUser.ID);
            if (User == null)
                return BadRequest("User not found.");

            User.Name = updatedUser.Name;
            User.Email = updatedUser.Email;
            User.Age = updatedUser.Age;

            await _context.SaveChangesAsync();

            return Ok(User);
        }

        [HttpDelete]
        public async Task<ActionResult<List<User>>> Delete(int ID)
        {
            var User = await _context.Users.FindAsync(ID);
            if (User == null)
                return BadRequest("User not found.");

            _context.Users.Remove(User);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Users.ToListAsync());
        }
    }
}
