using TestLibrary.Infrastructure.ReportInfrastructure.Abstract;

namespace TestLibrary.Infrastructure.ReportInfrastructure.Concrete
{
    public class ExecutionTimes : IExecutionTimes
    {
        public ExecutionTimes(double databaseTestTime, double applicationTestTime, double apiTestTime)
        {
            DatabaseTestTime = databaseTestTime;
            ApplicationTestTime = applicationTestTime;
            ApiTestTime = apiTestTime;
        }

        public double DatabaseTestTime { get; }
        public double ApplicationTestTime { get; }
        public double ApiTestTime { get; }
    }
}
