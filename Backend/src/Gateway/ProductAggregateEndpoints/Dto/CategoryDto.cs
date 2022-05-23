using Core.ProductAggregate;
namespace Gateway.ProductAggregateEndpoints.Dto;

public class CategoryDto : BaseDto
{
    public string Title { get; set; }
    public string? Description { get; set; }

    public CategoryDto(Category category) : base(category.Id, category.CreatedAt, category.UpdatedAt)
    {
        Title = category.Title;
        Description = category.Description;
    }
}
