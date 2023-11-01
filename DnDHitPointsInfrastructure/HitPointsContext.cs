using DnDHitPointsServices.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DnDHitPointsInfrastructure
{
    public class HitPointsContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public HitPointsContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(options => options.EnableRetryOnFailure());
            optionsBuilder.UseInMemoryDatabase(databaseName: "HitPointsDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HitPoints>();
        }

        public DbSet<HitPoints> HitPoints { get; set; }

    }
}
