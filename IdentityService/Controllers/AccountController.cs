using IdentityService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        
        [HttpGet("Test/{name}")]
        public ActionResult<string> Test(string name)
        {
            return Ok($"hello {name}, welcome!");
        }

        [HttpPost("CreateAccount")]
        public ActionResult<string> CreateAccount([FromBody] CreateAccount account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok($"send {account.Email} and {account.Password}");
        }
    }
}
