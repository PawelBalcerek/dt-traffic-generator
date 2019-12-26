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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Endpoint>().HasData(new Endpoint[] {
                new Endpoint{EndpointId = 1, EndpointName= "UserGetInfo", HttpMethod = "GET"},
                new Endpoint{EndpointId = 2, EndpointName= "UserRegister", HttpMethod = "POST"},
                new Endpoint{EndpointId = 3, EndpointName= "UserLogin", HttpMethod = "POST"},
                new Endpoint{EndpointId = 4, EndpointName= "UserLogout", HttpMethod = "GET"},
                new Endpoint{EndpointId = 5, EndpointName= "CompaniesShow", HttpMethod = "GET"},
                new Endpoint{EndpointId = 6, EndpointName= "CompaniesAdd", HttpMethod = "POST"},
                new Endpoint{EndpointId = 7, EndpointName= "ResourcesShow", HttpMethod = "GET"},
                new Endpoint{EndpointId = 8, EndpointName= "SellOffersShow", HttpMethod = "GET"},
                new Endpoint{EndpointId = 9, EndpointName= "SellOffersAdd", HttpMethod = "POST"},
                new Endpoint{EndpointId = 10, EndpointName= "SellOffersWithdraw", HttpMethod = "GET"},
                new Endpoint{EndpointId = 11, EndpointName= "BuyOffersShow", HttpMethod = "GET"},
                new Endpoint{EndpointId = 12, EndpointName= "BuyOffersAdd", HttpMethod = "POST"},
                new Endpoint{EndpointId = 13, EndpointName= "BuyOffersWithdraw", HttpMethod = "GET"},
                new Endpoint{EndpointId = 14, EndpointName= "TransactionsShow", HttpMethod = "GET"},
            });
        }
    }
}
