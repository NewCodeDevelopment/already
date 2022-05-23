using Ardalis.GuardClauses;
using Shared;
namespace Core.ProductAggregate;

public class ProductOption : BaseEntity
{
    // Relations
    public Guid ProductId { get; private set; }
    public Product Product { get; private set; } = default!;
    
    private readonly List<ProductOptionValue> _values = new();
    public IReadOnlyCollection<ProductOptionValue> Values => _values.AsReadOnly();
    
    
    // Properties
    public string Option { get; private set; }

    
    
    // Constructors
    private ProductOption(string option)
    {
        Option = Guard.Against.NullOrEmpty(option);
    }
    
    public ProductOption(string option, string value) :this(option)
    {
        AddProductOptionValue(new ProductOptionValue(value));
    }
    
    public ProductOption(string option, List<ProductOptionValue> values) :this(option)
    {
        AddProductOptionValue(values);
    }
    
    
    
    // Adding
    public void AddProductOptionValue(ProductOptionValue productOptionValue)
    {
        Guard.Against.Null(productOptionValue);
        productOptionValue.SetProductOption(this);
        _values.Add(productOptionValue);
    }
    
    public void AddProductOptionValue(List<ProductOptionValue> productOptionValues)
    {
        foreach (var productOptionValue in productOptionValues)
        {
            AddProductOptionValue(productOptionValue);
        }
    }
    
    
    
    // Setters
    public void SetProduct(Product product)
    {
        Guard.Against.Null(product);
        Product = product;
        ProductId = ProductId;
    }
}
