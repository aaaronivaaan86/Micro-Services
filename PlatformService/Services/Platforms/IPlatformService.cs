using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformService.Services.Platforms
{
    public interface IPlatformService
    {
        public IEnumerable<PlatformService.Models.Platform> GetAllPlatforms();
    }
}
