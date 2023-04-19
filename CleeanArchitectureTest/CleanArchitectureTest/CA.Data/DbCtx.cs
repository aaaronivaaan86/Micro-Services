using Microsoft.EntityFrameworkCore;
using CA.Domain;
using System;

namespace CA.Data
{
    public class DbCtx : DbContext
    {
        public DbCtx(DbContextOptions<DbCtx> opt) : base(opt)
        {

        }

        public DbSet<Platform> Platforms { get; set; }

    }
}
