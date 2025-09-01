using Microsoft.AspNetCore.Mvc;
using WebSimulator.Models;
using WebSimulator.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebSimulator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        // POST api/<AuthController>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            if (user.Username.Equals("admin") && user.Password.Equals("admin"))
            {   
                return Ok();
            }
            return BadRequest();
        }
    }
}
