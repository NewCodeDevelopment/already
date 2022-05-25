using Ardalis.GuardClauses;
namespace Core.OrderAggregate.OrderStates;

public abstract class IOrderState
{
    // Properties
    protected Order Order { get; init; }

    
    
    // Constructors
    protected IOrderState(Order order)
    {
        Order = Guard.Against.Null(order, nameof(order));
    }

    
    
    // Abstract methods
    public abstract void ProcessOrder();
    public abstract void ShipOrder();
    public abstract void ReceiveOrder();
}
