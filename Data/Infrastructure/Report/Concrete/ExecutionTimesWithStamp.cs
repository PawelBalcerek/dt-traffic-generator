using System;
using TestLibrary.Infrastructure.ReportInfrastructure.Abstract;

namespace Data.Infrastructure.Report.Concrete
{
    public class ExecutionTimesWithStamp : ExecutionTimes, IExecutionTimesWithStamp
    {
        public ExecutionTimesWithStamp(double databaseTestTime, double applicationTestTime, double apiTestTime, DateTime timeStamp) 
            : base(databaseTestTime, applicationTestTime, apiTestTime)
        {
            TimeStamp = timeStamp;
        }

        public DateTime TimeStamp { get; }
    }
}
