using Ardalis.Specification;
namespace Core.OrderAggregate.Specifications;

public class OrderByCustomerWithRelationsSpec : Specification<Order>
{
    public OrderByCustomerWithRelationsSpec(Guid customerId)
    {
        Query
            .Where(x => x.CustomerId == customerId)
            .Include(x => x.OrderItems).ThenInclude(x => x.ProductVariant)
            .Include(x => x.Customer);
    }
}
