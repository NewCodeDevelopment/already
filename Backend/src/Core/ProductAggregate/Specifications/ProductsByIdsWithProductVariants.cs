using Ardalis.Specification;
namespace Core.ProductAggregate.Specifications;

public class ProductsByIdsWithProductVariants : Specification<Product>
{
    public ProductsByIdsWithProductVariants(List<Guid> productIds)
    {
        Query
            .Where(x => productIds.Contains(x.Id))
            .Include(x => x.ProductVariants);
    }
}