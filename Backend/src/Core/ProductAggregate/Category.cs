using Ardalis.GuardClauses;
using Core.ProductAggregate.Exceptions;
using Shared;
using Shared.Interfaces;
namespace Core.ProductAggregate;

public class Category : BaseEntity, IAggregateRoot
{
    // Hierarchy
    public virtual Guid? ParentId { get; private set; }
    public virtual Category? Parent { get; private set; }
    
    private readonly List<Category>? _children;
    public IReadOnlyCollection<Category>? Children => _children?.AsReadOnly();
    
    
    
    // Relations
    private readonly List<Product> _products = new();
    public IReadOnlyCollection<Product> Products => _products.AsReadOnly();
    
    private readonly List<Shop> _shops = new();
    public IReadOnlyCollection<Shop> Shops => _shops.AsReadOnly();
    
    private readonly List<Brand> _brands = new();
    public IReadOnlyCollection<Brand> Brands => _brands.AsReadOnly();

    
    
    // Properties
    public string Title { get; private set; }
    public string? Description { get; private set; }
    
    
    
    // Constructors
    public Category(Guid? parentId, string title)
    {
        ParentId = parentId;
        Title = Guard.Against.NullOrEmpty(title, nameof(title));
    }
    
    public Category(Guid? parentId, List<Category> children, string title) : this(parentId, title)
    {
        _children = Guard.Against.Null(children, nameof(children));
    }

    public Category(Guid? parentId, string title, string description) : this(parentId, title)
    {
        Description = Guard.Against.NullOrEmpty(description, nameof(description));
    }   
    
    public Category(Guid? parentId, List<Category> children, string title, string description) : this(parentId, children, title)
    {
        Description = Guard.Against.NullOrEmpty(description, nameof(description));
    }
    
    
    // Adding
    public void AddProduct(Product product)
    {
        Guard.Against.Null(product, nameof(product));
        product.SetCategory(this);
        _products.Add(product);
    }    
}
