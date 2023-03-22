using CA.Domain;
using CA.Infraestructure.Repositories.Interfaces;
using CA.Infraestructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Infraestructure.Services
{
    public class PlatformService : IPlatformService
    {
        private readonly IPlatformRepo platformRepo;

        public PlatformService(IPlatformRepo platformRepo)
        {
            this.platformRepo = platformRepo;
        }


        public IEnumerable<Platform> GetPlatforms()
        {
            return this.platformRepo.GetPlatforms();
        }
    }
}
