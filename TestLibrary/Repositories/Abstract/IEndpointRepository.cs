using System.Collections.Generic;
using TestLibrary.BusinessObject.Abstract;

namespace TestLibrary.Repositories.Abstract
{
    public interface IEndpointRepository
    {
        IEndpoint GetEndpoint(long endpointId);
        IEnumerable<IEndpoint> GetEndpoints();
        void AddEndpoint(IEndpointBase endpoint);
    }
}
