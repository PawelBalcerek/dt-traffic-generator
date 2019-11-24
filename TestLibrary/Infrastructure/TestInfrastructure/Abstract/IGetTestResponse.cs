using TestLibrary.BusinessObject;
using TestLibrary.Infrastructure.Common.Abstract;

namespace TestLibrary.Infrastructure.TestInfrastructure.Abstract
{
    public interface IGetTestResponse : IResponseResult
    {
        Test Test { get; }
    }
}
