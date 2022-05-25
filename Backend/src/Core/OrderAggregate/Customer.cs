using Ardalis.GuardClauses;
using Core.IdentityAggregate;
using Core.ProductAggregate;
using Shared.Interfaces;
namespace Core.OrderAggregate;

public class Customer : ApplicationUser, IBaseEntity
{
    // Relations
    private List<Order> _orders = new();
    public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();
    
    public Guid BasketId { get; private set; }
    public Basket Basket { get; private set; }


    
    // Constructors
    public Customer(string firstName, string lastName, string email): base(firstName, lastName, email)
    {
        if (Basket is null)
        {
            var basket = new Basket();
            basket.SetCustomer(this);
            Basket = basket;
            BasketId = basket.Id;
        }
    }
    
    
    
    // Adding
    public void AddOrder(Order order)
    {
        Guard.Against.Null(order, nameof(order));
        order.SetCustomer(this);
        _orders.Add(order);
    }

    public void AddProductVariantToBasket(ProductVariant productVariant)
    {
        Guard.Against.Null(productVariant, nameof(productVariant));
        Basket.AddProductVariant(productVariant);
    }
}
