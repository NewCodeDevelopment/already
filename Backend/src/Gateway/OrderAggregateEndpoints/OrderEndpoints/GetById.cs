using Ardalis.ApiEndpoints;
using Core.OrderAggregate;
using Core.OrderAggregate.Specifications;
using Gateway.OrderAggregateEndpoints.Dto;
using Microsoft.AspNetCore.Mvc;
using Shared.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
namespace Gateway.OrderAggregateEndpoints.OrderEndpoints;

public class GetById : EndpointBaseAsync
    .WithRequest<BaseRequestById>
    .WithActionResult<BaseOrderResponse<OrderDto>>
{
    private readonly IRepository<Order> _repository;
  
    public GetById(IRepository<Order> repository)
    {
        _repository = repository;
    }

    [HttpGet(BaseRequest.OrderRoute + "/{Id}")]
    [SwaggerOperation(
        Summary = "Gets a single Order",
        Description = "Gets a single Order by Id",
        Tags = new[] { "Baskets" })
    ]
    public override async Task<ActionResult<BaseOrderResponse<OrderDto>>> HandleAsync([FromRoute] BaseRequestById request, CancellationToken cancellationToken = new CancellationToken())
    {
        var spec = new OrderByIdWithRelationsSpec(request.Id);
        var order = await _repository.GetBySpecAsync(spec, cancellationToken);
        if (order == null) return NotFound($"Order with id:{request.Id} not found");
        
        var dto = new OrderDto(order);
        var response = new BaseOrderResponse<OrderDto>(dto);
        return Ok(response);
    }
}
