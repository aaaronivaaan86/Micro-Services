using AutoMapper;
using CommandsService.Models.Dto;
using CommandsService.Repositorie.Command;
using CommandsService.Repositorie.Platform;
using Microsoft.AspNetCore.Mvc;
using CommandServiceModels = CommandService.Models;

namespace CommandsService.Controllers
{
    [Route("api/commands/platforms/{platformId}/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ILogger<PlatformsController> logger;
        private readonly IPlatformRepo platformRepository;
        private readonly ICommandRepo commandRepository;
        private readonly IMapper mapper;

        public CommandsController(ILogger<PlatformsController> logger, ICommandRepo commandRepository, IPlatformRepo platformRepository, IMapper mapper)
        {
            this.logger = logger;
            this.platformRepository = platformRepository;
            this.commandRepository = commandRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetCommandsForPlatform(int platformId)
        {
            Console.WriteLine($"--> Hit GetCommandsForPlatform: {platformId}");

            if (!this.platformRepository.PlaformExits(platformId))
            {
                return NotFound();
            }

            var commands = this.commandRepository.GetCommandsForPlatform(platformId);

            return Ok(this.mapper.Map<IEnumerable<CommandReadDto>>(commands));
        }

        [HttpGet("{commandId}", Name = "GetCommandForPlatform")]
        public ActionResult<CommandReadDto> GetCommandForPlatform(int platformId, int commandId)
        {
            Console.WriteLine($"--> Hit GetCommandForPlatform: {platformId} / {commandId}");

            if (!this.platformRepository.PlaformExits(platformId))
            {
                return NotFound();
            }

            var command = this.commandRepository.GetCommand(platformId, commandId);

            if (command == null)
            {
                return NotFound();
            }

            return Ok(this.mapper.Map<CommandReadDto>(command));
        }

        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommandForPlatform(int platformId, CommandCreateDto commandDto)
        {
            Console.WriteLine($"--> Hit CreateCommandForPlatform: {platformId}");

            if (!this.platformRepository.PlaformExits(platformId))
            {
                return NotFound();
            }

            var command = this.mapper.Map<CommandServiceModels.Command>(commandDto);

            this.commandRepository.CreateCommand(platformId, command);
            this.commandRepository.SaveChanges();

            var commandReadDto = this.mapper.Map<CommandReadDto>(command);

            return CreatedAtRoute(nameof(GetCommandForPlatform),
                new { platformId = platformId, commandId = commandReadDto.Id }, commandReadDto);
        }









    }
}
