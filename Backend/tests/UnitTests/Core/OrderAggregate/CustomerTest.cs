using System.Linq;
using Core.OrderAggregate;
using UnitTests.Core.TestFactories.OrderAggregates;
using Xunit;
namespace UnitTests.Core.OrderAggregate;

public class CustomerTest
{
    [Fact]
    public void InitializeFirstNameCustomer()
    {
        var testCustomer = TestCustomerFactory.Create();
        Assert.Equal(TestCustomerFactory.TestFirstName, testCustomer.FirstName);
    }
    
    [Fact]
    public void InitializeLastNameCustomer()
    {
        var testCustomer = TestCustomerFactory.Create();
        Assert.Equal(TestCustomerFactory.TestLastName, testCustomer.LastName);
    }
    
    [Fact]
    public void InitializeEmailCustomer()
    {
        var testCustomer = TestCustomerFactory.Create();
        Assert.Equal(TestCustomerFactory.TestEmail, testCustomer.Email);
    }
    
    [Fact]
    public void AddOrderToCustomer()
    {
        var testCustomer = TestCustomerFactory.Create();
        var testOrder = TestOrderFactory.Create();
        
        testCustomer.AddOrder(testOrder);
        
        Assert.Equal(1, testCustomer.Orders.Count);
        Assert.Equal(testOrder, testCustomer.Orders.First());
    }
    
    [Fact]
    public void SetCustomerToOrder()
    {
        var testCustomer = TestCustomerFactory.Create();
        var testOrder = TestOrderFactory.Create();
        
        testCustomer.AddOrder(testOrder);
        
        Assert.Equal(testOrder.Customer, testCustomer);
        Assert.Equal(testOrder.CustomerId, testCustomer.Id);
    }
}
