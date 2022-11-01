using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostalCodeService.Models;

namespace PostalCodeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostalCodesController : ControllerBase
    {
        public PostalCodesController()
        {

        }

        [HttpGet]
        public async Task<ActionResult> GetPostalCodeInfo()
        {
            return Ok("This endpoint is ready!!!");
        }


        [HttpGet("GetFakePostalCode")]
        public ActionResult<PostalCode> GetFakePostalCode()
        {
            return Ok(new PostalCode()
            {
                Id = 1,
                Name = "Campeche",
                IsActive = true,
            });
        }
    }
}
