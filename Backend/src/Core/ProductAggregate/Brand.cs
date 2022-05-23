using Ardalis.GuardClauses;
using Shared;
using Shared.Interfaces;
namespace Core.ProductAggregate;

public class Brand : BaseEntity, IAggregateRoot
{
    // Relations
    private readonly List<Product> _products = new();
    public IReadOnlyCollection<Product> Products => _products.AsReadOnly();
    
    private readonly List<Category> _categories = new();
    public IReadOnlyCollection<Category> Categories => _categories.AsReadOnly();
    
    private readonly List<Shop> _shops = new();
    public IReadOnlyCollection<Shop> Shops => _shops.AsReadOnly();
    
    
    
    // Properties
    public string Name { get; private set; }
    public string? Description { get; private set; }
    
    
    
    // Constructors
    public Brand(string name)
    {
        Name = Guard.Against.NullOrEmpty(name, nameof(name));
    }

    public Brand(string name, string description) : this(name)
    {
        Description = Guard.Against.NullOrEmpty(description, nameof(description));
    }
 
    
    // Adding
    public void AddProduct(Product product)
    {
        Guard.Against.Null(product, nameof(product));
        product.SetBrand(this);
        _products.Add(product);
    }
}
