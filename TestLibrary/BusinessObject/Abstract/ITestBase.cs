using System;

namespace TestLibrary.BusinessObject.Abstract
{
    public interface ITestBase
    {
        long TestParametersId { get; }
        long UserId { get; }
        long EndpointId { get; }
        double DatabaseTestTime { get; }
        double ApplicationTestTime { get; }
        double ApiTestTime { get; }
        DateTime TimeStamp { get; }
    }
}
