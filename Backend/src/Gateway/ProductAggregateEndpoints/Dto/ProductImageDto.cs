using Core.ProductAggregate;
namespace Gateway.ProductAggregateEndpoints.Dto;

public class ProductImageDto
{
    public string ImageUrl { get; set; }
    public string ImageAlt { get; set; }

    public ProductImageDto(ProductImage productImage)
    {
        ImageUrl = productImage.ImageUrl;
        ImageAlt = productImage.ImageAlt;
    }
}
