using Ardalis.ApiEndpoints;
using Core.OrderAggregate;
using Core.OrderAggregate.Specifications;
using Gateway.OrderAggregateEndpoints.Dto;
using Microsoft.AspNetCore.Mvc;
using Shared.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
namespace Gateway.OrderAggregateEndpoints.BasketEndpoints;

public class GetByCustomer : EndpointBaseAsync
    .WithRequest<BaseRequestById>
    .WithActionResult<BaseBasketResponse<BasketDto>>
{
    private readonly IRepository<Basket> _repository;
  
    public GetByCustomer(IRepository<Basket> repository)
    {
        _repository = repository;
    }

    [HttpGet(BaseRequest.BasketRoute + "/Customers/{Id}")]
    [SwaggerOperation(
        Summary = "Gets a single Basket",
        Description = "Gets a single Basket by Customer",
        Tags = new[] { "Baskets" })
    ]
    public override async Task<ActionResult<BaseBasketResponse<BasketDto>>> HandleAsync([FromRoute] BaseRequestById request, CancellationToken cancellationToken = new CancellationToken())
    {
        var spec = new BasketByCustomerWithRelationsSpec(request.Id);
        var basket = await _repository.GetBySpecAsync(spec, cancellationToken);
        if (basket == null) return NotFound($"Customer with id:{request.Id} is not found");

        var dto = new BasketDto(basket);
        var response = new BaseResponse<BasketDto>(dto);
        return Ok(response);
    }
}
