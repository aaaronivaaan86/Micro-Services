using CA.Domain;
using CA.Infraestructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CA.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformService platformService;

        public PlatformController(IPlatformService platformService)
        {
            this.platformService = platformService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Platform>> GetPlatforms()
        {
            return Ok(platformService.GetPlatforms());
        }





    }
}
