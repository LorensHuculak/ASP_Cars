using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LorensHuculak_ASP.Models;

namespace LorensHuculak_ASP.Models
{
    public class LorensHuculak_ASPContext : DbContext
    {
        public LorensHuculak_ASPContext (DbContextOptions<LorensHuculak_ASPContext> options)
            : base(options)
        {
        }

        public DbSet<LorensHuculak_ASP.Models.Car> Car { get; set; }

        public DbSet<LorensHuculak_ASP.Models.CarType> CarType { get; set; }

        public DbSet<LorensHuculak_ASP.Models.Owner> Owner { get; set; }
    }
}
