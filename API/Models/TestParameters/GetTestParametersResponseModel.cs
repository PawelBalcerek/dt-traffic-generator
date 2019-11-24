using TestLibrary.BusinessObject.Abstract;

namespace API.Models.TestParameters
{
    public class GetTestParametersResponseModel
    {
        public GetTestParametersResponseModel(ITestParameters testParameters)
        {
            TestParameters = testParameters;
        }

        public ITestParameters TestParameters { get; }
    }
}
