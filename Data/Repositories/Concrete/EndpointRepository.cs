using System;
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

        public IEndpoint GetEndpoint(int id)
        {
            //TESTS
            return DbContext.Endpoints.FirstOrDefault();
            //throw new NotImplementedException();
        }

        public IEndpoint GetEndpoint(string name, string httpMethod)
        {
            throw new NotImplementedException();
        }

        public long AddEndpoint(string endpointName, string httpMethod)
        {
            DbContext.Endpoints.Add(new Endpoint {EndpointName = endpointName, HttpMethod = httpMethod });
            DbContext.SaveChanges();
            //throw new NotImplementedException();
            return 1;
        }
    }
}
