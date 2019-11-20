using System.Collections.Generic;
using TestLibrary.BusinessObject;
using TestLibrary.Infrastructure.Common.Abstract;

namespace TestLibrary.Infrastructure.TestParametersInfrastructure.Abstract
{
    public interface IGetTestsParametersResponse : IResponseResult
    {
        IEnumerable<TestParameters> TestsParameters { get; }
    }
}
