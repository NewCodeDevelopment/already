using System.ComponentModel.DataAnnotations.Schema;
using SharedKernel.Interfaces;
namespace SharedKernel;

public abstract class BaseEntity: IBaseEntity
{
  public Guid Id { get; set; }
  
  public DateTimeOffset CreatedAt { get; set; }
  public DateTimeOffset UpdatedAt { get; set; }

  [NotMapped]
  public List<BaseDomainEvent> Events { get; } = new();
}
