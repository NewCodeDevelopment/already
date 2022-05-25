using Ardalis.GuardClauses;
using Core.ProductAggregate;
using Shared;
using Shared.Interfaces;
namespace Core.OrderAggregate;

public class Basket : BaseEntity, IAggregateRoot
{
    // Relations
    public Guid? CustomerId { get; private set; }
    public Customer? Customer { get; private set; }
    
    private List<ProductVariant> _productVariants = new();
    public IReadOnlyCollection<ProductVariant> ProductVariants => _productVariants.AsReadOnly();



    // Adding
    public void AddProductVariant(ProductVariant productVariant)
    {
        Guard.Against.Null(productVariant, nameof(productVariant));
        _productVariants.Add(productVariant);
    }
    
    public void AddProductVariant(List<ProductVariant> productVariants)
    {
        foreach (var productVariant in productVariants)
        {
            AddProductVariant(productVariant);
        }
    }
    
    
    // Removing
    public void RemoveProductVariant(ProductVariant productVariant)
    {
        Guard.Against.Null(productVariant, nameof(productVariant));
        _productVariants.Remove(productVariant);
    }
    
    public void RemoveProductVariant(List<ProductVariant> productVariants)
    {
        foreach (var productVariant in productVariants)
        {
            RemoveProductVariant(productVariant);
        }
    }
    
    
    // Has
    public bool HasProductVariant(ProductVariant productVariant)
    {
        return _productVariants.Find(x => x.Id == productVariant.Id) != null;
    }
    
    
    
    // Setters
    public void SetCustomer(Customer customer)
    {
        Guard.Against.Null(customer);
        Customer = customer;
        CustomerId = customer.Id;
    }
}
