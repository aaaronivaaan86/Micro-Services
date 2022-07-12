using CommandService.Data;
using CommandServiceModels = CommandService.Models;


namespace CommandsService.Repositorie.Command
{
    public class CommandRepo : ICommandRepo
    {
        private readonly AppDbContext context;

        public CommandRepo(AppDbContext context)
        {
            this.context = context;
        }

        public void CreateCommand(int platformId, CommandServiceModels.Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            command.PlatformId = platformId;
            this.context.Commands.Add(command);
        }

        public CommandServiceModels.Command GetCommand(int platformId, int commandId)
        {
            return this.context.Commands
                .Where(c => c.PlatformId == platformId && c.Id == commandId).FirstOrDefault();
        }

        public IEnumerable<CommandServiceModels.Command> GetCommandsForPlatform(int platformId)
        {
            return this.context.Commands
                .Where(c => c.PlatformId == platformId)
                .OrderBy(c => c.Platform.Name);
        }

        public bool SaveChanges()
        {
            return (this.context.SaveChanges() >= 0);
        }

    }
}
