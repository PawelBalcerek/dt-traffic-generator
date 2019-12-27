using TestLibrary.BusinessObject.Abstract;

namespace TestLibrary.Infrastructure.ReportInfrastructure.Concrete.Model
{
    public class EndpointExecutionTimesModel : ExecutionTimes, IEndpoint
    {
        public EndpointExecutionTimesModel(long endpointId, string endpointName, string httpMethod, double databaseTestTime, double applicationTestTime, double apiTestTime) 
            : base(databaseTestTime, applicationTestTime, apiTestTime)
        {
            EndpointId = endpointId;
            EndpointName = endpointName;
            HttpMethod = httpMethod;
        }

        public long EndpointId { get; }
        public string EndpointName { get; }
        public string HttpMethod { get; }
    }
}
