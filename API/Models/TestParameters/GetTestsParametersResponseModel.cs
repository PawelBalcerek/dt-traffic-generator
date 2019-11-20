using System.Collections.Generic;
using TestLibrary.BusinessObject.Abstract;

namespace API.Models.TestParameters
{
    public class GetTestsParametersResponseModel
    {
        public GetTestsParametersResponseModel(IEnumerable<ITestParameters> testsParameters)
        {
            TestsParameters = testsParameters;
        }

        public IEnumerable<ITestParameters> TestsParameters { get; }
    }
}
