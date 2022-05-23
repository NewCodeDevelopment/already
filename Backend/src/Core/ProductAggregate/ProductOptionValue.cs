using Ardalis.GuardClauses;
using Shared;
namespace Core.ProductAggregate;

public class ProductOptionValue : BaseEntity
{
    // Relations
    public Guid ProductOptionId { get; private set; }
    public ProductOption ProductOption { get; private set; } = default!; 
    
    private readonly List<ProductVariant> _productVariants = new();
    public IReadOnlyCollection<ProductVariant> ProductVariants => _productVariants.AsReadOnly();
    
    
    // Properties
    public string Value { get; private set; }

    
    // Constructors
    public ProductOptionValue(string value)
    {
        Value = Guard.Against.NullOrEmpty(value);
    }
    
    
    // Add
    public void AddProductVariant(ProductVariant productVariant)
    {
        Guard.Against.Null(productVariant, nameof(productVariant));
        _productVariants.Add(productVariant);
    }
    
    
    // Setters
    public void SetProductOption(ProductOption productOption)
    {
        Guard.Against.Null(productOption, nameof(productOption));
        ProductOption = productOption;
        ProductOptionId = productOption.Id;
    }
}
