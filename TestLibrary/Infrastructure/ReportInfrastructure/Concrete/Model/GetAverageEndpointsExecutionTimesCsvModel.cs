namespace TestLibrary.Infrastructure.ReportInfrastructure.Concrete.Model
{
    public class GetAverageEndpointsExecutionTimesCsvModel
    {
        public GetAverageEndpointsExecutionTimesCsvModel(long endpointId, string endpointName, string httpMethod, double databaseTestTime, double applicationTestTime, double apiTestTime)
        {
            EndpointId = endpointId;
            EndpointName = endpointName;
            HttpMethod = httpMethod;
            DatabaseTestTime = databaseTestTime;
            ApplicationTestTime = applicationTestTime;
            ApiTestTime = apiTestTime;
        }

        public long EndpointId { get; set; }
        public string EndpointName { get; set; }
        public string HttpMethod { get; set; }

        public double DatabaseTestTime { get; set; }
        public double ApplicationTestTime { get; set; }
        public double ApiTestTime { get; set; }
    }
}
