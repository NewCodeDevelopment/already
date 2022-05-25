using Core.OrderAggregate;
using Core.ProductAggregate;
using Gateway.ProductAggregateEndpoints.Dto;
namespace Gateway.OrderAggregateEndpoints.Dto;

public class BasketDto : BaseDto
{
    public CustomerDto Customer { get; set; }
    public IEnumerable<ProductVariantDto> ProductVariants { get; set; }

    public BasketDto(Basket basket) : base(basket.Id, basket.CreatedAt, basket.UpdatedAt)
    {
        Customer = new CustomerDto(basket.Customer);
        ProductVariants = basket.ProductVariants.Select(x => new ProductVariantDto(x));
    }
}
