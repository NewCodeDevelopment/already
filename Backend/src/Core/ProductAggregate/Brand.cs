using Shared;
using Shared.Interfaces;
namespace Core.ProductAggregate;

public class Brand : BaseEntity
{
    // Relations
    private readonly List<Product> _products = new();
    private readonly List<Category> _categories = new();
    private readonly List<Shop> _shops = new();
    
    
    // Properties
    public string Name { get; private set; }
}
