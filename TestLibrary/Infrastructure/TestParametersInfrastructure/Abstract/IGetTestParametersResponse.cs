using TestLibrary.BusinessObject;
using TestLibrary.Infrastructure.Common.Abstract;

namespace TestLibrary.Infrastructure.TestParametersInfrastructure.Abstract
{
    public interface IGetTestParametersResponse : IResponseResult
    {
        TestParameters TestParameters { get; }
    }
}
