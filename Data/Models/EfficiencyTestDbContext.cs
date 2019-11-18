using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class EfficiencyTestDbContext : DbContext
    {
        public EfficiencyTestDbContext(DbContextOptions<EfficiencyTestDbContext> options) : base(options) { }

        public virtual DbSet<TestParameters> TestsParameters { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<Endpoint> Endpoints { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    }
}
