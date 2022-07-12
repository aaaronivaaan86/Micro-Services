using AutoMapper;
using CommandsService.Models.Dto;
using CommandsService.Repositorie.Command;
using CommandsService.Repositorie.Platform;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
    [Route("api/command/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly ILogger<PlatformsController> _logger;
        private readonly IPlatformRepo repository;
        private readonly IMapper mapper;

        public PlatformsController(ILogger<PlatformsController> logger, IPlatformRepo repository, IMapper mapper )
        {
            _logger = logger;
            this.repository = repository;
            this.mapper = mapper;
        }


        [HttpPost]
        public ActionResult TestInboubd()
        {
            Console.WriteLine("--> Command Service Post Inbound");
            return Ok("Command Service Post Inbound");
        }


        [HttpGet]
        public ActionResult<IEnumerable<PlatformreadDto>> GetPlatforms()
        {
            Console.WriteLine("--> Getting Platforms from CommandsService");

            var platformItems = this.repository.GetAllPlatforms();

            return Ok(this.mapper.Map<IEnumerable<PlatformreadDto>>(platformItems));
        }


    }
}
