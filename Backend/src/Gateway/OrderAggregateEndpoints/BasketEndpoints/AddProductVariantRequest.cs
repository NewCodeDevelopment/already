using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
namespace Gateway.OrderAggregateEndpoints.BasketEndpoints;

public class AddProductVariantRequest : BaseRequestById
{
    [Required] 
    [FromBody] public AddProductVariantRequestBody Body { get; set; } = default!;
}

public class AddProductVariantRequestBody
{
    [Required] 
    public List<AddProductVariantRequestBodyBasketItem> Items { get; set; }
}

public class AddProductVariantRequestBodyBasketItem
{
    public Guid ProductId { get; set; }
    public List<Guid> ProductVariantIds { get; set; }
}