using Core.OrderAggregate;
namespace Gateway.OrderAggregateEndpoints.Dto;

public class CustomerDto : BaseDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public CustomerDto(Customer customer): base(customer.Id, customer.CreatedAt, customer.UpdatedAt)
    {
        FirstName = customer.FirstName;
        LastName = customer.LastName;
        Email = customer.Email;
    }
}
