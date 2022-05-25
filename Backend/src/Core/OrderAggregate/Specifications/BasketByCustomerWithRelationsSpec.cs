using Ardalis.Specification;
namespace Core.OrderAggregate.Specifications;

public class BasketByCustomerWithRelationsSpec : Specification<Basket>, ISingleResultSpecification
{
    public BasketByCustomerWithRelationsSpec(Guid customerId)
    {
        Query
            .Where(x => x.CustomerId == customerId)
            .Include(x => x.Customer)
            .Include(x => x.ProductVariants).ThenInclude(x => x.Product);
    }
}
