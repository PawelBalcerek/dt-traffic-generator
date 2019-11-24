using System;
using System.Collections.Generic;
using System.Linq;
using Data.Models;
using Data.Repositories.Abstract;
using TestLibrary.BusinessObject.Abstract;
using TestLibrary.Repositories.Abstract;

namespace Data.Repositories.Concrete
{
    public class EndpointRepository : RepositoryBase, IEndpointRepository
    {
        public EndpointRepository(EfficiencyTestDbContext dbContext) : base(dbContext) { }


        public IEndpoint GetEndpoint(long endpointId)
        {
            return DbContext.Endpoints.FirstOrDefault(p => p.EndpointId == endpointId);
        }

        public IEnumerable<IEndpoint> GetEndpoints()
        {
            return DbContext.Endpoints;
        }

        public void AddEndpoint(IEndpointBase endpoint)
        {
            Endpoint endpointDataModel = new Endpoint(endpoint.EndpointName, endpoint.HttpMethod);
            DbContext.Endpoints.Add(endpointDataModel);
            DbContext.SaveChanges();
        }
    }
}
