namespace TestLibrary.BusinessObject.Abstract
{
    public interface ITestParametersBase
    {
        string TestName { get; }
        int NumberOfUsers { get; }
        int NumberOfRequests { get; }
        double MinBuyPrice { get; }
        double MaxBuyPrice { get; }
        double MinSellPrice { get; }
        double MaxSellPrice { get; }
    }
}
