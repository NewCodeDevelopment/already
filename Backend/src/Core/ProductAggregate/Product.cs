using Ardalis.GuardClauses;
using Shared;
using Shared.Interfaces;
namespace Core.ProductAggregate;

public class Product : BaseEntity, IAggregateRoot
{
    //Relations
    public Guid ShopId { get; private set; }
    public Guid BrandId { get; private set; }
    public Guid CategoryId { get; private set; }
    
    // Properties
    public string Title { get; private set; }

    
}
