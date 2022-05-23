using Core.ProductAggregate;
namespace Gateway.ProductAggregateEndpoints.Dto;

public class BrandDto : BaseDto
{
    public string Name { get; set; }
    public string? Description { get; set; }

    public BrandDto(Brand brand) : base(brand.Id, brand.CreatedAt, brand.UpdatedAt)
    {
        Name = brand.Name;
        Description = brand.Description;
    }
}
