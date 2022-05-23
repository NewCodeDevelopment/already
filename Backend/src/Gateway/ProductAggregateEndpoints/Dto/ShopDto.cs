using Core.ProductAggregate;
namespace Gateway.ProductAggregateEndpoints.Dto;

public class ShopDto : BaseDto
{
    public string Name { get; set; }
    public int Rating { get; set; }
    public string LogoUrl { get; set; }

    public ShopDto(Shop shop) : base(shop.Id, shop.CreatedAt, shop.UpdatedAt)
    {
        Name = shop.Name;
        Rating = shop.Rating;
        LogoUrl = shop.LogoUrl;
    }
}
