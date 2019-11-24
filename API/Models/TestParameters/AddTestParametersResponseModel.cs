using TestLibrary.BusinessObject.Abstract;

namespace API.Models.TestParameters
{
    public class AddTestParametersResponseModel
    {
        public AddTestParametersResponseModel(ITestParameters addedTestParameters)
        {
            AddedTestParameters = addedTestParameters;
        }

        public ITestParameters AddedTestParameters { get; }
    }
}
