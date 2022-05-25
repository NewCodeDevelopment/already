using Core.OrderAggregate.Exceptions;
namespace Core.OrderAggregate.OrderStates;

public class OrderProcessedState : IOrderState
{
    // Constructor
    public OrderProcessedState(Order order): base(order)
    {
    }

    
    // State Methods
    public override void ProcessOrder()
    {
        throw new OrderStateNotPermittedException(this, nameof(OrderProcessedState));
    }
    
     public override void ShipOrder()
    {
        Order.SetState(new OrderShippedState(Order));
    }

     public override void ReceiveOrder()
    {
        throw new OrderStateNotPermittedException(this, nameof(OrderReceivedState));
    }
}
