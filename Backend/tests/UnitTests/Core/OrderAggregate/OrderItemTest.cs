using UnitTests.Core.TestFactories.OrderAggregates;
using Xunit;
namespace UnitTests.Core.OrderAggregate;

public class OrderItemTest
{
    [Fact]
    public void AddOrderItemToOrderOnInitialize()
    {
        var testOrderItems = TestOrderItemFactory.CreateList();
        var testOrder = TestOrderFactory.Create(testOrderItems);
        
        Assert.Equal(testOrderItems.Count, testOrder.OrderItems.Count);
        Assert.Equal(testOrderItems, testOrder.OrderItems);
    }
    
    [Fact]
    public void SetOrderOnOrderItem()
    {
        var testOrderItems = TestOrderItemFactory.CreateList();
        var testOrder = TestOrderFactory.Create(testOrderItems);

        foreach (var orderItem in testOrder.OrderItems)
        {
            Assert.Equal(testOrderItems.Count, testOrder.OrderItems.Count);
            Assert.Equal(testOrderItems, testOrder.OrderItems);
        }
    }
    
    [Fact]
    public void SetProductVariantToOrderItem()
    {
        var testOrderItems = TestOrderItemFactory.CreateList();
        var testOrder = TestOrderFactory.Create(testOrderItems);

        foreach (var orderItem in testOrder.OrderItems)
        {
            Assert.NotNull(orderItem.ProductVariant);
        }
    }
}
