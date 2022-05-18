using System.ComponentModel.DataAnnotations.Schema;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;
using Shared;
using Shared.Interfaces;

namespace Core.IdentityAggregate;

public class ApplicationUser : IdentityUser<Guid>, IAggregateRoot, IBaseEntity
{
  public string FirstName { get; protected set; }
  public string LastName { get; protected set; }

  public DateTimeOffset CreatedAt { get; set; }
  public DateTimeOffset UpdatedAt { get; set; }
  
  [NotMapped]
  public List<BaseDomainEvent> Events { get; } = new();
  
  public ApplicationUser(string firstName, string lastName, string email)
  {
    FirstName = Guard.Against.NullOrEmpty(firstName, nameof(firstName));
    LastName = Guard.Against.NullOrEmpty(lastName, nameof(lastName));
    Email = Guard.Against.NullOrEmpty(email, nameof(email));
  }

}
