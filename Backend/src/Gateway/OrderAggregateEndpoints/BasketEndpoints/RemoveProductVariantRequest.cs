using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
namespace Gateway.OrderAggregateEndpoints.BasketEndpoints;

public class RemoveProductVariantRequest : BaseRequestById
{
    [Required] 
    [FromBody] public RemoveProductVariantRequestBody Body { get; set; } = default!;
}

public class RemoveProductVariantRequestBody
{
    [Required] 
    public List<RemoveProductVariantRequestBodyBasketItem> Items { get; set; }
}

public class RemoveProductVariantRequestBodyBasketItem
{
    public Guid ProductId { get; set; }
    public List<Guid> ProductVariantIds { get; set; }
}