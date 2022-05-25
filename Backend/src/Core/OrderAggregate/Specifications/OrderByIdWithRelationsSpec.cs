using Ardalis.Specification;
namespace Core.OrderAggregate.Specifications;

public class OrderByIdWithRelationsSpec : Specification<Order>, ISingleResultSpecification
{
    public OrderByIdWithRelationsSpec(Guid orderId)
    {
        Query
            .Where(x => x.Id == orderId)
            .Include(x => x.Customer)
            .Include(x => x.OrderItems).ThenInclude(x => x.ProductVariant).ThenInclude(x => x.Product);
    }
}
