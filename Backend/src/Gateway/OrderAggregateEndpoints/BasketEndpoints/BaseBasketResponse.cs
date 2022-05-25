using Gateway.OrderAggregateEndpoints.Dto;

namespace Gateway.OrderAggregateEndpoints.BasketEndpoints;

public class BaseBasketResponse<T> where T : BasketDto
{
    public T Basket { get; set; }

    public BaseBasketResponse(T basket)
    {
        Basket = basket;
    }
}

public class BaseBasketResponseList
{
    public List<BasketDto> Baskets { get; set; }

    public BaseBasketResponseList(List<BasketDto> baskets)
    {
        Baskets = baskets;
    }
}