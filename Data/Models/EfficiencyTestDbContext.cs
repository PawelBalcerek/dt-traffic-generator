using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class EfficiencyTestDbContext : DbContext
    {
        public virtual DbSet<TestParameters> TestsParameters { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<Endpoint> Endpoints { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-OQ06NJ3;Database=EfficiencyTest;Trusted_Connection=True;");
        }
    }
}
