using Data.Models;
using Data.Repositories.Abstract;
using System.Linq;
using TestLibrary.BusinessObject.Abstract;
using TestLibrary.Repositories.Abstract;

namespace Data.Repositories.Concrete
{
    public class TestParametersRepository : RepositoryBase, ITestParametersRepository
    {
        public TestParametersRepository(EfficiencyTestDbContext dbContext) : base(dbContext) { }


        public ITestParameters GetTestParameters(long testParametersId)
        {
            return DbContext.TestsParameters.Where(p => p.TestParametersId == testParametersId).FirstOrDefault();
        }

        public long AddTestParameters()
        {
            throw new System.NotImplementedException();
        }
    }
}
