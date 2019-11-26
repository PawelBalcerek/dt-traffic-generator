using System;

namespace TestLibrary.BusinessObject.Abstract
{
    public interface ITestBase
    {
        int TestParametersId { get; }
        int UserId { get; }
        int EndpointId { get; }
        DateTime DatabaseTestTime { get; }
        DateTime ApplicationTestTime { get; }
        DateTime ApiTestTime { get; }
        DateTime TimeStamp { get; }
    }
}
