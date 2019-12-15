using System.Collections.Generic;
using TestLibrary.Infrastructure.ReportInfrastructure.Abstract;

namespace API.Models.Report
{
    public class GetUsersEnpointExecutionTimesResponseModel
    {
        public GetUsersEnpointExecutionTimesResponseModel(IEnumerable<IUserEndpointExecutionTimes> usersEndpointExecutionTimes)
        {
            UsersEndpointExecutionTimes = usersEndpointExecutionTimes;
        }

        public IEnumerable<IUserEndpointExecutionTimes> UsersEndpointExecutionTimes;
    }
}
