using JobTo.API.Data;
using JobTo.Common.Helpers;
using JobTo.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace JobTo.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JobToContext _context;
        private readonly ILogger _logger;
        public AuthController(JobToContext context, ILogger<AuthController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate(
            [FromBody]User model)
        {
            var password = Crypt.Encrypt(model.Password);
            
            var user = await _context.Users.Where(
                x => x.Username == model.Username && x.Password == password)
                .FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound(new User());
            }
            var token = TokenService.GenerateToken(user);
            user.Password = "";
            user.Token = token;

            return Ok(user);
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<dynamic>> RegisterUser(
            [FromBody]User model)
        {
            var modelClean = model;
            modelClean.Password = Crypt.Encrypt(model.Password);
            model.Role = "User";
            
            var user = _context.Users.Add(modelClean);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfile", new { id = modelClean.Id }, user);
        }

        [HttpGet("{id}")]
        [Route("profile/{id}")]
        public async Task<ActionResult<User>> GetProfile(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            user.Password = string.Empty;
            return Ok(user);
        }
    }
}
