using Core.OrderAggregate.OrderStates;
namespace Core.OrderAggregate.Exceptions;

public class OrderStateNotPermittedException : Exception
{
    public OrderStateNotPermittedException(IOrderState thisState, string toState) :base($"Setting {toState.ToString()} is not permitted on {thisState.ToString()}") {}
}
