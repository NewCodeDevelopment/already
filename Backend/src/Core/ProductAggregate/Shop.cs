using Shared;
namespace Core.ProductAggregate;

public class Shop : BaseEntity
{
    // Relations
    private readonly List<Product> _products = new();
    private readonly List<Category> _categories = new();
    private readonly List<Brand> _brands = new();
    
    // Properties
    public string Name { get; private set; }
    
}
