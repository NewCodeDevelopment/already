using Ardalis.GuardClauses;
using Shared;
namespace Core.ProductAggregate;

public class ProductImage : BaseEntity
{
    // Relations
    public Guid? ProductId { get; private set; }
    public Product? Product { get; private set; }


    // Properties
    public string ImageUrl { get; private set; }
    public string ImageAlt { get; private set; }

    
    // Constructors
    public ProductImage(string imageUrl, string imageAlt)
    {
        ImageUrl = Guard.Against.NullOrEmpty(imageUrl, nameof(imageUrl));
        ImageAlt = Guard.Against.NullOrEmpty(imageAlt, nameof(imageAlt));;
    }
    
    
    // Setters
    public void SetProduct(Product product)
    {
        Guard.Against.Null(product);
        Product = product;
        ProductId = product.Id;
    }
}
