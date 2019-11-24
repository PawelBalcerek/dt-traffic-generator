using System.Collections.Generic;
using Data.Models;
using Data.Repositories.Abstract;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TestLibrary.BusinessObject.Abstract;
using TestLibrary.Repositories.Abstract;

namespace Data.Repositories.Concrete
{
    public class TestParametersRepository : RepositoryBase, ITestParametersRepository
    {
        public TestParametersRepository(EfficiencyTestDbContext dbContext) : base(dbContext) { }


        public ITestParameters GetTestParameters(long testParametersId)
        {
            return DbContext.TestsParameters.FirstOrDefault(p => p.TestParametersId == testParametersId);
        }

        public IEnumerable<ITestParameters> GetTestsParameters()
        {
            return DbContext.TestsParameters;
        }

        public ITestParameters AddTestParameters(ITestParameters testParameters)
        {
            TestParameters testParametersDataModel = new TestParameters(testParameters.TestParametersId, testParameters.TestName, testParameters.NumberOfUsers, testParameters.NumberOfRequests, testParameters.MinBuyPrice, testParameters.MaxBuyPrice, testParameters.MinSellPrice, testParameters.MaxSellPrice);
            EntityEntry<TestParameters> entityEntry = DbContext.TestsParameters.Add(testParametersDataModel);
            DbContext.SaveChanges();
            return entityEntry.Entity;
        }
    }
}
