using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Shared;
using Shared.Interfaces;

namespace Core.IdentityAggregate;

public class ApplicationRole : IdentityRole<Guid>, IBaseEntity
{
  public DateTimeOffset CreatedAt { get; set; }
  public DateTimeOffset UpdatedAt { get; set; }
  [NotMapped]
  public List<BaseDomainEvent> Events { get; } = new();
}
