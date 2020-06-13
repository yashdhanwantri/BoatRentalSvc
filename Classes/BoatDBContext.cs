using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRentalSvc.Classes
{
    public class BoatDbContext: DbContext
    {
        public BoatDbContext(DbContextOptions options): base(options)
        {

        }
        DbSet<Boat> Boats { get; set; }
    }
}
