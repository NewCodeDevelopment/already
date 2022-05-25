using Core.OrderAggregate;
namespace Gateway.OrderAggregateEndpoints.Dto;

public class OrderDto : BaseDto
{
    public string State { get; set; }
    public CustomerDto Customer { get; set; }
    public IEnumerable<OrderItemDto> OrderItems { get; set; }

    
    public OrderDto(Order order): base(order.Id, order.CreatedAt, order.UpdatedAt)
    {
        State = order.State.GetType().Name;
        Customer = new CustomerDto(order.Customer);
        OrderItems = order.OrderItems.Select(x => new OrderItemDto(x));
    }
}
