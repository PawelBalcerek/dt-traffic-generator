using System;
using Data.Models;
using Data.Repositories.Abstract;
using TestLibrary.BusinessObject.Abstract;
using TestLibrary.Repositories.Abstract;

namespace Data.Repositories.Concrete
{
    public class TestRepository : RepositoryBase, ITestRepository
    {
        public TestRepository(EfficiencyTestDbContext dbContext) : base(dbContext) { }

        public ITest GetTest(int id)
        {
            throw new NotImplementedException();
        }

        public long AddTest()
        {
            throw new NotImplementedException();
        }
    }
}
