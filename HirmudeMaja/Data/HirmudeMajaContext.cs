using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HirmudeMaja.Models;

namespace HirmudeMaja.Data
{
    public class HirmudeMajaContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Seikleja>()
                .HasIndex(e => new { e.Eesnimi })
                .IsUnique();
        }
        public HirmudeMajaContext(DbContextOptions<HirmudeMajaContext> options)
            : base(options)
        {
        }
        public DbSet<HirmudeMaja.Models.Seikleja> Seikleja { get; set; }
    }
}
