using Core.ProductAggregate;
namespace Gateway.ProductAggregateEndpoints.Dto;

public class ProductVariantDto
{
    public double Price { get;  set; }
    public int Quantity { get;  set; }
    public string? Sku { get;  set; }
    public string? Barcode { get;  set; }
    public IEnumerable<string> OptionValues { get; set; }
    
    public ProductVariantDto(ProductVariant productVariant)
    {
        Price = productVariant.Price;
        Quantity = productVariant.StockQuantity;
        Sku = productVariant.Sku;
        Barcode = productVariant.Barcode;
        OptionValues = productVariant.ProductOptionValues.Select(x => x.Value);
    }
}
