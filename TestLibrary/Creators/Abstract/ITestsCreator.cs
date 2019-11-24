using System.Collections.Generic;
using TestLibrary.BusinessObject;
using TestLibrary.Infrastructure.TestInfrastructure.Abstract;

namespace TestLibrary.Creators.Abstract
{
    public interface ITestsCreator
    {
        IAddTestsResponse AddTests(IEnumerable<Test> tests);
    }
}
