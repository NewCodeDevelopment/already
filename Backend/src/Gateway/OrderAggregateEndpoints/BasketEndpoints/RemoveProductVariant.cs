using Ardalis.ApiEndpoints;
using Core.OrderAggregate;
using Core.OrderAggregate.Specifications;
using Core.ProductAggregate;
using Core.ProductAggregate.Specifications;
using Gateway.OrderAggregateEndpoints.Dto;
using Microsoft.AspNetCore.Mvc;
using Shared.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
namespace Gateway.OrderAggregateEndpoints.BasketEndpoints;

public class RemoveProductVariant : EndpointBaseAsync
    .WithRequest<RemoveProductVariantRequest>
    .WithActionResult<BaseBasketResponse<BasketDto>>
{
    private readonly IRepository<Basket> _basketRepository;
    private readonly IRepository<Product> _productRepository;
    
    public RemoveProductVariant(IRepository<Basket> basketRepository, IRepository<Product> productRepository)
    {
        _basketRepository = basketRepository;
        _productRepository = productRepository;
    }

    [HttpDelete(BaseRequest.BasketRoute + "/Customers/{Id}")]
    [SwaggerOperation(
        Summary = "Remove ProductVariant to Basket",
        Description = "Remove ProductVariant to Basket",
        Tags = new[] { "Baskets" })
    ]
    public override async Task<ActionResult<BaseBasketResponse<BasketDto>>> HandleAsync([FromRoute] RemoveProductVariantRequest request,
        CancellationToken cancellationToken = new CancellationToken())
    {
        // Getting Ids
        var productIds = request.Body.Items.Select(x => x.ProductId).ToList();
        var productVariantIds = request.Body.Items.SelectMany(x => x.ProductVariantIds).ToList();
        
        
        // Get all Products by ids
        var productSpec = new ProductsByIdsWithProductVariants(productIds);
        var products = await _productRepository.ListAsync(productSpec, cancellationToken);

        
        // Get all ProductVariants by ids
        var productVariants = products.SelectMany(x => x.ProductVariants)
            .Where(x => productVariantIds.Contains(x.Id)).ToList();
        if (productVariants == null || productVariants.Count == 0) return NotFound($"ProductVariants with ids:{productVariantIds} not found");

        
        // Get Basket
        var basketSpec = new BasketByCustomerWithRelationsSpec(request.Id);
        var basket = await _basketRepository.GetBySpecAsync(basketSpec);
        if (basket == null) return NotFound($"Basket with customerId:{request.Id} not found");

        
        // Adding variants to basket
        try
        {
            basket.RemoveProductVariant(productVariants);
            await _basketRepository.UpdateAsync(basket, cancellationToken);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        // Response
        var dto = new BasketDto(basket);
        var response = new BaseBasketResponse<BasketDto>(dto);
        return Ok(response);
    }
}
