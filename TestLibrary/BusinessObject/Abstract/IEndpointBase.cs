namespace TestLibrary.BusinessObject.Abstract
{
    public interface IEndpointBase
    {
        string EndpointName { get; }
        string HttpMethod { get; }
    }
}
