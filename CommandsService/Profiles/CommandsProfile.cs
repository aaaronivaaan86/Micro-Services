using AutoMapper;
using CommandService.Models;
using CommandsService.Models.Dto;

namespace CommandsService.Profiles
{
    public class CommandsProfile : Profile
    {
        // Source -> Target
        public CommandsProfile()
        {
            CreateMap<Platform, PlatformreadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<Command, CommandReadDto>();
            CreateMap<PlatformPublishedDto, Platform>()
                    .ForMember(dest => dest.ExternalID, opt => opt.MapFrom(src => src.Id));
        }

    }
}
