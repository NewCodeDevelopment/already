using Core.OrderAggregate.Exceptions;
using Core.OrderAggregate.OrderStates;
using UnitTests.Core.TestFactories.OrderAggregates;
using Xunit;
namespace UnitTests.Core.OrderAggregate;

public class OrderStateTest
{
    [Fact]
    public void OrderProcess()
    {
        var testOrderItems = TestOrderItemFactory.CreateList();
        var testOrder = TestOrderFactory.Create(testOrderItems);

        testOrder.Process();
        
        Assert.Equal(testOrder.State.ToString(), new OrderProcessedState(testOrder).ToString());
    }
    
    [Fact]
    public void OrderShip()
    {
        var testOrderItems = TestOrderItemFactory.CreateList();
        var testOrder = TestOrderFactory.Create(testOrderItems);

        testOrder.Process();
        testOrder.Ship();
        
        Assert.Equal(testOrder.State.ToString(), new OrderShippedState(testOrder).ToString());
    }
    
    [Fact]
    public void OrderReceive()
    {
        var testOrderItems = TestOrderItemFactory.CreateList();
        var testOrder = TestOrderFactory.Create(testOrderItems);

        testOrder.Process();
        testOrder.Ship();
        testOrder.Receive();
        
        Assert.Equal(testOrder.State.ToString(), new OrderReceivedState(testOrder).ToString());
    }
    
    
    
    // Fail Tests on process method
    [Fact]
    public void FailToRunProcessInProcessedState()
    {
        var testOrderItems = TestOrderItemFactory.CreateList();
        var testOrder = TestOrderFactory.Create(testOrderItems);
        
        testOrder.Process();
        
        var action = () => testOrder.Process();
        Assert.Throws<OrderStateNotPermittedException>(action);
    }
    
    [Fact]
    public void FailToRunProcessInShippedState()
    {
        var testOrderItems = TestOrderItemFactory.CreateList();
        var testOrder = TestOrderFactory.Create(testOrderItems);
        
        testOrder.Process();
        testOrder.Ship();
        
        var action = () => testOrder.Process();
        Assert.Throws<OrderStateNotPermittedException>(action);
    }
    
    [Fact]
    public void FailToRunProcessInReceivedState()
    {
        var testOrderItems = TestOrderItemFactory.CreateList();
        var testOrder = TestOrderFactory.Create(testOrderItems);
        
        testOrder.Process();
        testOrder.Ship();
        testOrder.Receive();
        
        var action = () => testOrder.Process();
        Assert.Throws<OrderStateNotPermittedException>(action);
    }
    
    
    
    // Fail Tests on ship method
    [Fact]
    public void FailToRunShipInPlacedState()
    {
        var testOrderItems = TestOrderItemFactory.CreateList();
        var testOrder = TestOrderFactory.Create(testOrderItems);

        var action = () => testOrder.Ship();
        Assert.Throws<OrderStateNotPermittedException>(action);
    }
    
    [Fact]
    public void FailToRunShipInShipState()
    {
        var testOrderItems = TestOrderItemFactory.CreateList();
        var testOrder = TestOrderFactory.Create(testOrderItems);
        
        testOrder.Process();
        testOrder.Ship();

        var action = () => testOrder.Ship();
        Assert.Throws<OrderStateNotPermittedException>(action);
    }
    
    [Fact]
    public void FailToRunShipInReceiveState()
    {
        var testOrderItems = TestOrderItemFactory.CreateList();
        var testOrder = TestOrderFactory.Create(testOrderItems);
        
        testOrder.Process();
        testOrder.Ship();
        testOrder.Receive();
        
        var action = () => testOrder.Ship();
        Assert.Throws<OrderStateNotPermittedException>(action);
    }
    
    
    
    
    // Fail Tests on receive method
    [Fact]
    public void FailToRunReceiveInPlacedState()
    {
        var testOrderItems = TestOrderItemFactory.CreateList();
        var testOrder = TestOrderFactory.Create(testOrderItems);

        var action = () => testOrder.Receive();
        Assert.Throws<OrderStateNotPermittedException>(action);
    }
    
    [Fact]
    public void FailToRunReceiveInProcessedState()
    {
        var testOrderItems = TestOrderItemFactory.CreateList();
        var testOrder = TestOrderFactory.Create(testOrderItems);
        
        testOrder.Process();

        var action = () => testOrder.Receive();
        Assert.Throws<OrderStateNotPermittedException>(action);
    }
    
    [Fact]
    public void FailToRunReceiveInReceivedState()
    {
        var testOrderItems = TestOrderItemFactory.CreateList();
        var testOrder = TestOrderFactory.Create(testOrderItems);
        
        testOrder.Process();
        testOrder.Ship();
        testOrder.Receive();

        var action = () => testOrder.Receive();
        Assert.Throws<OrderStateNotPermittedException>(action);
    }
}
