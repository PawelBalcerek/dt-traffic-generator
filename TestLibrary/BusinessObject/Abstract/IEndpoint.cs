namespace TestLibrary.BusinessObject.Abstract
{
    public interface IEndpoint
    {
        int EndpointId { get; }
        string EndpointName { get; }
        string HttpMethod { get; }
    }
}
