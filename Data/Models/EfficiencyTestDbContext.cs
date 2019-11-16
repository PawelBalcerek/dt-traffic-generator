using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class EfficiencyTestDbContext : DbContext
    {
        public virtual DbSet<TestParameters> TestsParameters { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<Endpoint> Endpoints { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=efduaa.postgres.database.azure.com;Port = 5432;Database=EfficiencyTest;User Id = l01@efduaa;Password = PolitechnikaRzeszowska2019;");
        }
    }
}
