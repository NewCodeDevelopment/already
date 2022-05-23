using Core.ProductAggregate;
namespace Gateway.ProductAggregateEndpoints.Dto;

public class ProductOptionDto 
{
    public string Option { get; set; }
    public IEnumerable<string> Values { get; set; }

    public ProductOptionDto(ProductOption productOption)
    {
        Option = productOption.Name;
        Values = productOption.Values.Select(x=> x.Value);
    }
}
