using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VehiclistTest.Models;

namespace LorensHuculak_ASP.Models
{
    public class LorensHuculak_ASPContext : DbContext
    {
        public LorensHuculak_ASPContext (DbContextOptions<LorensHuculak_ASPContext> options)
            : base(options)
        {
        }

        public DbSet<VehiclistTest.Models.Car> Car { get; set; }

        public DbSet<VehiclistTest.Models.CarType> CarType { get; set; }

        public DbSet<VehiclistTest.Models.Owner> Owner { get; set; }
    }
}
