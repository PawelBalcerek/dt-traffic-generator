namespace TestLibrary.Infrastructure.ReportInfrastructure.Abstract
{
    public interface IExecutionTimes
    {
        double DatabaseTestTime { get; }
        double ApplicationTestTime { get; }
        double ApiTestTime { get; }
    }
}
