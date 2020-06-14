using BoatRentalSvc.Models;
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BoatRental>()
                .HasOne(p => p.Boat)
                .WithMany(b => b.BoatRentals)
                .HasForeignKey(p => p.BoatId);
        }
        public DbSet<BoatRental> BoatRentals { get; set; }
        public DbSet<Boat> Boats { get; set; }
    }
}
