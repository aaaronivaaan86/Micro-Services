using CommandServiceModels = CommandService.Models;


namespace CommandsService.Repositorie.Platform
{
    public interface IPlatformRepo {
        bool SaveChanges();

        // Platforms
        IEnumerable<CommandServiceModels.Platform> GetAllPlatforms();
        void CreatePlatform(CommandServiceModels.Platform plat);
        bool PlaformExits(int platformId);
        bool ExternalPlatformExists(int externalPlatformId);
    }

}
