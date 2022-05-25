using System;
using System.Collections.Generic;
using Core.OrderAggregate;
using Core.OrderAggregate.OrderStates;
using UnitTests.Core.TestFactories.OrderAggregates;
using Xunit;
using Xunit.Abstractions;

namespace UnitTests.Core.OrderAggregate;

public class OrderTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public OrderTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void InitialState()
    {
        var testOrderItems = TestOrderItemFactory.CreateList();
        var testOrder = TestOrderFactory.Create(testOrderItems);
        
        Assert.Equal(testOrder.State.ToString(), new OrderPlacedState(testOrder).ToString());
    }
    
    [Fact]
    public void InitialOrderPlacedDate()
    {
        var testOrderItems = TestOrderItemFactory.CreateList();
        var testOrder = TestOrderFactory.Create(testOrderItems);
        
        Assert.Equal(testOrder.OrderPlacedDate.Date, DateTimeOffset.Now.Date);
        Assert.Equal(testOrder.OrderPlacedDate.Hour, DateTimeOffset.Now.Hour);
        Assert.Equal(testOrder.OrderPlacedDate.Minute, DateTimeOffset.Now.Minute);
        Assert.Equal(testOrder.OrderPlacedDate.Second, DateTimeOffset.Now.Second);
    }

    [Fact]
    public void AddOrderItemOnInitialize()
    {
        var testOrderItems = TestOrderItemFactory.CreateList();
        var testOrder = TestOrderFactory.Create(testOrderItems);
        
        Assert.Equal(testOrder.OrderItems.Count, testOrderItems.Count);
        Assert.Equal(testOrder.OrderItems, testOrderItems);
    }
    
    [Fact]
    public void SetOrderToOrderItem()
    {
        var testOrderItem = new List<OrderItem>() {TestOrderItemFactory.Create()};
        var testOrder = TestOrderFactory.Create(testOrderItem);

        foreach (var orderItem in testOrder.OrderItems)
        {
            Assert.Equal(testOrder, orderItem.Order);
            Assert.Equal(testOrder.Id, orderItem.OrderId);
        }
    }
}
