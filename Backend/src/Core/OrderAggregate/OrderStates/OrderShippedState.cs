using Core.OrderAggregate.Exceptions;
namespace Core.OrderAggregate.OrderStates;

public class OrderShippedState : IOrderState
{
    // Constructor
    public OrderShippedState(Order order): base(order) {}

    
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
        Order.SetState(new OrderReceivedState(Order));
    }
}
