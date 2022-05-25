using Gateway.OrderAggregateEndpoints.Dto;
namespace Gateway.OrderAggregateEndpoints.OrderEndpoints;

public class BaseOrderResponse<T> where T : OrderDto
{
    public T Order { get; set; }

    public BaseOrderResponse(T order)
    {
        Order = order;
    }
}

public class BaseOrderResponseList
{
    public List<OrderDto> Orders { get; set; }

    public BaseOrderResponseList(List<OrderDto> orders)
    {
        Orders = orders;
    }
}
