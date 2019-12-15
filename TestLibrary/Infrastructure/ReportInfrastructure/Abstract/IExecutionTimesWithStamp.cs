using System;

namespace TestLibrary.Infrastructure.ReportInfrastructure.Abstract
{
    public interface IExecutionTimesWithStamp : IExecutionTimes
    {
        DateTime TimeStamp { get; }
    }
}
