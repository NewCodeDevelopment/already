using Core.OrderAggregate.Exceptions;
namespace Core.OrderAggregate.OrderStates;

public class OrderPlacedState : IOrderState
{
    // Constructors
    public OrderPlacedState(Order order): base(order) {}
    
    
    // State methods

    public override void ProcessOrder()
    {
        Order.SetState(new OrderProcessedState(Order));
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
