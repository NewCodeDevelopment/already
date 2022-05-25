using Core.OrderAggregate;
namespace UnitTests.Core.TestFactories.OrderAggregates;

public static class TestCustomerFactory
{
    public static string TestFirstName = "Koen";
    public static string TestLastName = "Slagers";
    public static string TestEmail = "koen.slagers@gmail.com";

    public static Customer Create()
    {
        return new Customer(TestFirstName, TestLastName, TestEmail);
    }
    
    public static Customer Create(Order order)
    {
        return new Customer(TestFirstName, TestLastName, TestEmail);
    }
}
