using Core.OrderAggregate.Exceptions;
namespace Core.OrderAggregate.OrderStates;

public class OrderReceivedState : IOrderState
{
    // Constructor
    public OrderReceivedState(Order order): base(order){}

    
    // State Methods
    public override void ProcessOrder()
    {
        throw new OrderStateNotPermittedException(this, nameof(OrderProcessedState));
    }
    
    public override void ShipOrder()
    {
        throw new OrderStateNotPermittedException(this, nameof(OrderShippedState));
    }

    public override void ReceiveOrder()
    {
        throw new OrderStateNotPermittedException(this, nameof(OrderReceivedState));
    }
}
