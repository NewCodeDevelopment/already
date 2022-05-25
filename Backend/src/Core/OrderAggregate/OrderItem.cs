using Ardalis.GuardClauses;
using Core.ProductAggregate;
using Shared;
namespace Core.OrderAggregate;

public class OrderItem : BaseEntity
{
    // Relations
    public Guid? OrderId { get; private set; }
    public Order? Order { get; private set; }
    
    public Guid ProductVariantId { get; private set; }
    public ProductVariant ProductVariant { get; private set; }
    
    
    // Properties
    public double Price { get; private set; }
    public int OrderQuantity { get; private set; }
    
    
    // Constructor
    private OrderItem(int orderQuantity)
    {
        OrderQuantity = Guard.Against.Null(orderQuantity, nameof(orderQuantity));
    }
    
    public OrderItem(int orderQuantity, ProductVariant productVariant):this(orderQuantity)
    {
        Guard.Against.Null(productVariant, nameof(productVariant));
        Price = productVariant.Price;

        ProductVariant = productVariant;
        ProductVariantId = productVariant.Id;
    }
    
    
    // Setters
    public void SetOrder(Order order)
    {
        Guard.Against.Null(order, nameof(order));
        Order = order;
        OrderId = order.Id;
    }
}
