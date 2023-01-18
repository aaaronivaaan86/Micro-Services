using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostalCodeService.Models;
using PostalCodeService.Services;

namespace PostalCodeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostalCodesController : ControllerBase
    {
        private readonly IPostalCodeService postalCodeService;

        public PostalCodesController(IPostalCodeService postalCodeService)
        {
            this.postalCodeService = postalCodeService;
        }

        [HttpGet]
        public async Task<ActionResult> GetPostalCodeInfo()
        {
            var postalcodeList = await this.postalCodeService.GetPostalCodes();
            return Ok(postalcodeList);
        }


        [HttpGet("GetFakePostalCode")]
        public ActionResult<PostalCode> GetFakePostalCode()
        {
            return Ok(new PostalCode()
            {
                Id = "1",
                Name = "Campeche",
                IsActive = true,
            });
        }

        [HttpPost("AddPostalCode")]
        public async Task<ActionResult<PostalCode>> AddPostalCode(PostalCode postalCode)
        {
            var result = await this.postalCodeService.AddPostalCode(postalCode);  
            return Ok(result);  
        }
    }
}
