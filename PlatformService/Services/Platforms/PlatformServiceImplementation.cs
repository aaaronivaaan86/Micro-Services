using PlatformService.Data;
using PlatformService.Services.Platforms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformService.Services.Platforms
{
    public class PlatformServiceImplementation : IPlatformService
    {
        private readonly IPlatformRepo platformRepo;

        public PlatformServiceImplementation(IPlatformRepo platformRepo)
        {
            this.platformRepo = platformRepo;
        }

        public IEnumerable<Models.Platform> GetAllPlatforms()
        {
            return this.platformRepo.GetAllPlatforms();
        }
    }
}
