using TestLibrary.BusinessObject.Abstract;

namespace TestLibrary.Repositories.Abstract
{
    public interface IEndpointRepository
    {
        IEndpoint GetEndpoint(int id);
        IEndpoint GetEndpoint(string name, string httpMethod);
        long AddEndpoint(string endpointName, string httpMethod);
    }
}
