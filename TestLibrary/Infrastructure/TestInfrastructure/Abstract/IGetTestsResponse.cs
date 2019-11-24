using System.Collections.Generic;
using TestLibrary.BusinessObject;
using TestLibrary.Infrastructure.Common.Abstract;

namespace TestLibrary.Infrastructure.TestInfrastructure.Abstract
{
    public interface IGetTestsResponse : IResponseResult
    {
        IEnumerable<Test> Tests { get; }
    }
}
