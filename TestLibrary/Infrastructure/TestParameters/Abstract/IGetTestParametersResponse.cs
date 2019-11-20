using TestLibrary.Infrastructure.Common.Abstract;

namespace TestLibrary.Infrastructure.TestParameters.Abstract
{
    public interface IGetTestParametersResponse : IResponseResult
    {
        BusinessObject.TestParameters TestParameters { get; }
    }
}
