using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;
using PlatformService.Services;
using PlatformService.SyncDataServices.Http;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo repository;
        private readonly IMapper mapper;
        private readonly ICommandDataClient commandDataClient;

        public PlatformsController(
            IPlatformRepo repository, 
            IMapper mapper,
            ICommandDataClient commandDataClient )

        {
            this.repository = repository;
            this.mapper = mapper;
            this.commandDataClient = commandDataClient;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {            

            ConsoleWriteService.WriteLine("-> Getting Platforms....");   
            var platforms = this.repository.GetAllPlatforms();
            return Ok(this.mapper.Map<IEnumerable<PlatformReadDto>>(platforms));
        }

        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(int id)
        {
            var platformItem = this.repository.GetPlatformById(id);
            if (platformItem != null)
            {
                return Ok(this.mapper.Map<PlatformReadDto>(platformItem));
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<PlatformReadDto>> CreatePlatform(PlatformCreateDto platformCreateDto)
        {

            ConsoleWriteService.WriteLine(" Creating Platform....");
            var platformModel = this.mapper.Map<Platform>(platformCreateDto);
            this.repository.CreatePlatform(platformModel);
            this.repository.SaveChanges();

            var platformReadDto = this.mapper.Map<PlatformReadDto>(platformModel);

            // Send Sync Message
            try
            {
                await this.commandDataClient.SendPlatformToCommand(platformReadDto);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"--> Could not send synchronously: {ex.Message}");
            }

            // Send Async Message
            // try
            // {
            //     var platformPublishedDto = _mapper.Map<PlatformPublishedDto>(platformReadDto);
            //     platformPublishedDto.Event = "Platform_Published";
            //     _messageBusClient.PublishNewPlatform(platformPublishedDto);
            // }
            // catch (Exception ex)
            // {
            //     Console.WriteLine($"--> Could not send asynchronously: {ex.Message}");
            // }
            ConsoleWriteService.WriteLine(" Platform created....");
            return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformReadDto.Id}, platformReadDto);
        }
    }
}