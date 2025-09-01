using Microsoft.AspNetCore.Mvc;
using WebSimulator.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebSimulator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // GET: api/<VAuthController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<VAuthController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VAuthController>
        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            if (user.Username.Equals("admin") && user.Password.Equals("admin"))
            {
                return Ok();
            }
            return BadRequest();
        }

        // PUT api/<VAuthController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VAuthController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
