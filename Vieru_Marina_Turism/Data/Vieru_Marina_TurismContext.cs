using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vieru_Marina_Turism.Models;

namespace Vieru_Marina_Turism.Data
{
    public class Vieru_Marina_TurismContext : DbContext
    {
        public Vieru_Marina_TurismContext(DbContextOptions<Vieru_Marina_TurismContext> options)
            : base(options)
        {
        }

        public DbSet<Vieru_Marina_Turism.Models.Holiday> Holiday { get; set; } = default!;

        public DbSet<Vieru_Marina_Turism.Models.Flight>? Flight { get; set; }

        public DbSet<Vieru_Marina_Turism.Models.Favourite>? Favourite { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Favourite>()
                .HasOne(f => f.Holiday)
                .WithOne(h => h.Favourite)
                .HasForeignKey<Favourite>(f => f.HolidayID)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Vieru_Marina_Turism.Models.Member>? Member { get; set; }
    }
}
