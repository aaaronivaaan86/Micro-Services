using CA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Infraestructure.Repositories.Interfaces
{
    public interface IPlatformRepo
    {
        IEnumerable<Platform> GetPlatforms();
    }
}
