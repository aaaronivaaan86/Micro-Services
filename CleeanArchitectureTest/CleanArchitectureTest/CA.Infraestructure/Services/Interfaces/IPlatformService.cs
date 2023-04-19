using CA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Infraestructure.Services.Interfaces
{
    public interface IPlatformService
    {
        IEnumerable<Platform> GetPlatforms();
    }
}
