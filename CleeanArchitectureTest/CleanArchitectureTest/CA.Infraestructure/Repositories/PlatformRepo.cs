using CA.Domain;
using CA.Infraestructure.Repositories.Interfaces;
using CA.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Infraestructure.Repositories
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly DbCtx dbCtx;

        public PlatformRepo(DbCtx dbCtx)
        {
            this.dbCtx = dbCtx;
        }



        public IEnumerable<Platform> GetPlatforms()
        {
            return this.dbCtx.Platforms.ToList();
        }


        public Platform CreatePlatform(Platform platform)
        {
            throw new NotImplementedException();
        }

        public Platform GetPlatformById(int platformId)
        {
            throw new NotImplementedException();
        }
    }
}
