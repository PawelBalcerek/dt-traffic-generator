using System.Collections.Generic;
using TestLibrary.BusinessObject.Abstract;

namespace API.Models.Test
{
    public class GetTestsResponseModel
    {
        public GetTestsResponseModel(IEnumerable<ITest> tests)
        {
            Tests = tests;
        }

        public IEnumerable<ITest> Tests { get; }
    }
}
