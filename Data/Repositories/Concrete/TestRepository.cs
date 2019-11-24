using System.Collections.Generic;
using System.Linq;
using Data.Models;
using Data.Repositories.Abstract;
using TestLibrary.BusinessObject.Abstract;
using TestLibrary.Repositories.Abstract;

namespace Data.Repositories.Concrete
{
    public class TestRepository : RepositoryBase, ITestRepository
    {
        public TestRepository(EfficiencyTestDbContext dbContext) : base(dbContext) { }

        public ITest GetTest(long testId)
        {
            return DbContext.Tests.FirstOrDefault(p => p.TestId == testId);
        }

        public IEnumerable<ITest> GetTests()
        {
            return DbContext.Tests;
        }

        public void AddTests(IEnumerable<ITestBase> tests)
        {
            IEnumerable<Test> testDataModels = tests.Select(p => new Test(p.TestParametersId, p.UserId, p.EndpointId, p.DatabaseTestTime, p.ApplicationTestTime, p.ApiTestTime));
            DbContext.Tests.AddRange(testDataModels);
            DbContext.SaveChanges();
        }
    }
}
