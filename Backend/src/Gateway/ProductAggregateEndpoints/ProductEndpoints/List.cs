using Ardalis.ApiEndpoints;
using Core.ProductAggregate;
using Core.ProductAggregate.Specifications;
using Gateway.ProductAggregateEndpoints.Dto;
using Microsoft.AspNetCore.Mvc;
using Shared.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
namespace Gateway.ProductAggregateEndpoints.ProductEndpoints;

public class List : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult<BaseProductResponseList>
{
    private readonly IRepository<Product> _repository;
  
    public List(IRepository<Product> repository)
    {
        _repository = repository;
    }

    [HttpGet(BaseRequest.ProductRoute)]
    [SwaggerOperation(
        Summary = "Gets a list of Products",
        Description = "Gets a list of Products",
        Tags = new[] { "Products" })
    ]
    public override async Task<ActionResult<BaseProductResponseList>> HandleAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var spec = new ProductWithRelationsSpec();
        var products = await _repository.ListAsync(spec);

        var dto = products.Select(product => new ProductDto(product)).ToList();
        var response = new BaseProductResponseList(dto);
        return response;

    }
}
