using System;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
    [Route("api/command/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly ILogger<PlatformsController> _logger;

        public PlatformsController(ILogger<PlatformsController> logger)
        {
            _logger = logger;
        }


        [HttpPost]
        public ActionResult TestInboubd()
        {
            Console.WriteLine("--> Command Service Post Inbound");
            return Ok("Command Service Post Inbound");
        }



    }
}
