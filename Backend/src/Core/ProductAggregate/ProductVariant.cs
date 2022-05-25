using Ardalis.GuardClauses;
using Core.OrderAggregate;
using Shared;
namespace Core.ProductAggregate;

public class ProductVariant : BaseEntity
{
    // Relations
    public Guid ProductId { get; private set; }
    public Product? Product { get; private set; }
    
    private readonly List<ProductOptionValue> _productOptionValues = new();
    public IReadOnlyCollection<ProductOptionValue> ProductOptionValues => _productOptionValues.AsReadOnly();


    // Properties
    public double Price { get; private set; }
    public int StockQuantity { get; private set; }
    public string? Sku { get; private set; }
    public string? Barcode { get; private set; }

    
    
    // Constructors
    public ProductVariant(double price, int stockQuantity)
    {
        Price = Guard.Against.NegativeOrZero(price, nameof(price));
        StockQuantity = Guard.Against.NegativeOrZero(stockQuantity, nameof(stockQuantity));
    }
    
    public ProductVariant(double price, int stockQuantity, ProductOptionValue productOptionValue)
        :this(price, stockQuantity)
    {
        AddProductOptionValue(productOptionValue);
    }
    
    public ProductVariant(double price, int stockQuantity, List<ProductOptionValue> productOptionValues)
        :this(price, stockQuantity)
    {
        AddProductOptionValue(productOptionValues);
    }
    
    
    
    // Add
    private void AddProductOptionValue(ProductOptionValue productOptionValue)
    {
        Guard.Against.Null(productOptionValue);
        productOptionValue.AddProductVariant(this);
        _productOptionValues.Add(productOptionValue);
    }
    
    private void AddProductOptionValue(List<ProductOptionValue> productOptionValues)
    {
        foreach (var productOptionValue in productOptionValues)
        {
            AddProductOptionValue(productOptionValue);
        }
    }
    
    
    
    // Setters
    public void SetProduct(Product product)
    {
        Guard.Against.Null(product, nameof(product));
        Product = product;
        ProductId = product.Id;
    }


    // Has
    public bool HasProductOptionValues()
    {
        return _productOptionValues.Count > 0;
    }
}
