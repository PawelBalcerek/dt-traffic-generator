using Data.Models;

namespace Data.Repositories.Abstract
{
    public abstract class RepositoryBase
    {
        protected EfficiencyTestDbContext DbContext { get; set; }

        protected RepositoryBase(EfficiencyTestDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
