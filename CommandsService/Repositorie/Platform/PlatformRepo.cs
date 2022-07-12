using CommandService.Data;
using CommandServiceModels = CommandService.Models;

namespace CommandsService.Repositorie.Platform
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext context;

        public PlatformRepo(AppDbContext context)
        {
            this.context = context;
        }

        public void CreatePlatform(CommandServiceModels.Platform plat)
        {
            if (plat == null)
            {
                throw new ArgumentNullException(nameof(plat));
            }
            this.context.Platforms.Add(plat);
        }

        public bool ExternalPlatformExists(int externalPlatformId)
        {
            return this.context.Platforms.Any(p => p.ExternalID == externalPlatformId);
        }

        public IEnumerable<CommandServiceModels.Platform> GetAllPlatforms()
        {
            return this.context.Platforms.ToList();
        }

        public bool PlaformExits(int platformId)
        {
            return this.context.Platforms.Any(p => p.Id == platformId);
        }

        public bool SaveChanges()
        {
            return (this.context.SaveChanges() >= 0);
        }
    }

}
