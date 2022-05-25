using System.Collections.Generic;
using Core.OrderAggregate;
namespace UnitTests.Core.TestFactories.OrderAggregates;

public static class TestOrderFactory
{
    // Creating Methods
    public static Order Create()
    {
        return new Order(TestOrderItemFactory.CreateList());
    }
    
    public static Order Create(List<OrderItem> orderItems)
    {
        return new Order(orderItems);
    }
}
