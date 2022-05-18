using Shared;
using Shared.Interfaces;
namespace Core.ProductAggregate;

public class Category : BaseEntity
{
    // Relations
    private readonly List<Product> _products = new();
    private readonly List<Shop> _shops = new();
    private readonly List<Brand> _brands = new();

    // Properties
    public string Title { get; private set; }
}
