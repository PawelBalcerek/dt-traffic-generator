using TestLibrary.BusinessObject.Abstract;

namespace API.Models.Test
{
    public class GetTestResponseModel
    {
        public GetTestResponseModel(ITest test)
        {
            Test = test;
        }

        public ITest Test { get; }
    }
}
