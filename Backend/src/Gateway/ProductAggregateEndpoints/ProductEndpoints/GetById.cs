using Ardalis.ApiEndpoints;
using Core.ProductAggregate;
using Core.ProductAggregate.Specifications;
using Gateway.OrderAggregateEndpoints.Dto;
using Gateway.ProductAggregateEndpoints.Dto;
using Microsoft.AspNetCore.Mvc;
using Shared.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
namespace Gateway.ProductAggregateEndpoints.ProductEndpoints;

public class GetById : EndpointBaseAsync
    .WithRequest<BaseRequestById>
    .WithActionResult<BaseProductResponse<ProductDto>>
{
    private readonly IRepository<Product> _repository;
  
    public GetById(IRepository<Product> repository)
    {
        _repository = repository;
    }

    [HttpGet(BaseRequest.ProductRoute + "/{Id}")]
    [SwaggerOperation(
        Summary = "Gets a single Product",
        Description = "Gets a single Product by Id",
        Tags = new[] { "Products" })
    ]
    public override async Task<ActionResult<BaseProductResponse<ProductDto>>> HandleAsync([FromRoute] BaseRequestById request, CancellationToken cancellationToken = new CancellationToken())
    {
        var spec = new ProductByIdWithRelationsSpec(request.Id);
        var product = await _repository.GetBySpecAsync(spec, cancellationToken);
        if (product == null) return NotFound($"Order by id:{request.Id} not found");

        var dto = new ProductDto(product);
        var response = new BaseProductResponse<ProductDto>(dto);
        return Ok(response);
    }
}
