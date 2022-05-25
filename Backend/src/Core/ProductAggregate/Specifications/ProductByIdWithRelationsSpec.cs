using Ardalis.Specification;
namespace Core.ProductAggregate.Specifications;

public class ProductByIdWithRelationsSpec : Specification<Product>, ISingleResultSpecification
{
    public ProductByIdWithRelationsSpec(Guid productId)
    {
        Query
            .Where(x => x.Id == productId)
            .Include(x => x.Brand)
            .Include(x => x.Shop)
            .Include(x => x.Category)
            .Include(x => x.ProductVariants).ThenInclude(x=> x.ProductOptionValues)
            .Include(x => x.ProductOptions).ThenInclude(x=> x.Values);
    }
}
