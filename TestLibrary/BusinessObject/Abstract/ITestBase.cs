using System;

namespace TestLibrary.BusinessObject.Abstract
{
    public interface ITestBase
    {
        int TestParametersId { get; }
        int UserId { get; }
        int EndpointId { get; }
        double DatabaseTestTime { get; }
        double ApplicationTestTime { get; }
        double ApiTestTime { get; }
        DateTime TimeStamp { get; }
    }
}
