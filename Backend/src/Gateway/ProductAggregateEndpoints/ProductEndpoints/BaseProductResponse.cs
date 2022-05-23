using Gateway.ProductAggregateEndpoints.Dto;

namespace Gateway.ProductAggregateEndpoints.ProductEndpoints;

public class BaseProductResponse<T> where T : ProductDto
{
    public T Product { get; set; }

    public BaseProductResponse(T product)
    {
        Product = product;
    }
}

public class BaseProductResponseList
{
    public List<ProductDto> Products { get; set; }

    public BaseProductResponseList(List<ProductDto> products)
    {
        Products = products;
    }
}
