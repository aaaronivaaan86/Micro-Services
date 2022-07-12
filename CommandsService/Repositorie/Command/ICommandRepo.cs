using CommandServiceModels = CommandService.Models;

namespace CommandsService.Repositorie.Command
{
    public interface ICommandRepo
    {
        bool SaveChanges();

        // Platforms
        //IEnumerable<CommandServiceModels.Platform> GetAllPlatforms();
        //void CreatePlatform(CommandServiceModels.Platform);
        //bool PlaformExits(int platformId);
        //bool ExternalPlatformExists(int externalPlatformId);

        // Commands
        IEnumerable<CommandServiceModels.Command> GetCommandsForPlatform(int platformId);
        CommandServiceModels.Command GetCommand(int platformId, int commandId);
        void CreateCommand(int platformId, CommandServiceModels.Command command);
    }
}
