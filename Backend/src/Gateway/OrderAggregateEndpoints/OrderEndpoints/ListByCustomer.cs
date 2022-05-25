using Ardalis.ApiEndpoints;
using Core.OrderAggregate;
using Core.OrderAggregate.Specifications;
using Gateway.OrderAggregateEndpoints.Dto;
using Microsoft.AspNetCore.Mvc;
using Shared.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
namespace Gateway.OrderAggregateEndpoints.OrderEndpoints;

public class ListByCustomer : EndpointBaseAsync
    .WithRequest<BaseRequestById>
    .WithActionResult<BaseOrderResponseList>
{
    private readonly IRepository<Order> _repository;
  
    public ListByCustomer(IRepository<Order> repository)
    {
        _repository = repository;
    }
    
    [HttpGet(BaseRequest.OrderRoute + "/Customers/{Id}")]
    [SwaggerOperation(
        Summary = "Gets a list of Orders by customer",
        Description = "Gets a list of Orders by customer",
        Tags = new[] { "Orders" })
    ]
    public override async Task<ActionResult<BaseOrderResponseList>> HandleAsync([FromRoute] BaseRequestById request, CancellationToken cancellationToken = new CancellationToken())
    {
        var spec = new OrderByCustomerWithRelationsSpec(request.Id);
        var orders = await _repository.ListAsync(spec, cancellationToken);
        if (orders == null || orders.Count == 0)
            return NotFound($"Orders not found on customerId:{request.Id}");

        var dto = orders.Select(product => new OrderDto(product)).ToList();
        var response = new BaseOrderResponseList(dto);
        return response;
    }
}
