using Ardalis.GuardClauses;
using Shared;
using Shared.Interfaces;
namespace Core.ProductAggregate;

public class Shop : BaseEntity, IAggregateRoot
{
    // Relations
    private readonly List<Product> _products = new();
    public IReadOnlyCollection<Product> Products => _products.AsReadOnly();
    
    private readonly List<Category> _categories = new();
    public IReadOnlyCollection<Category> Categories => _categories.AsReadOnly();
    
    private readonly List<Brand> _brands = new();
    public IReadOnlyCollection<Brand> Brands => _brands.AsReadOnly();
    
    
    // Properties
    public string Name { get; private set; }
    public int Rating { get; private set; }
    public string LogoUrl { get; private set; }
    public string? Description { get; private set; }

    
    // Constructors
    public Shop(string name, int rating, string logoUrl)
    {
        Name = Guard.Against.NullOrEmpty(name, nameof(name));
        Rating = Guard.Against.Negative(rating, nameof(rating));
        LogoUrl = Guard.Against.NullOrEmpty(logoUrl, nameof(logoUrl));
    }


    // Adding
    public void AddProduct(Product product)
    {
        Guard.Against.Null(product, nameof(product));
        product.SetShop(this);
        _products.Add(product);
    }   
}
