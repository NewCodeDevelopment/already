using MediatR;
using Microsoft.EntityFrameworkCore;

namespace SharedKernel;

[Keyless]
public abstract class BaseDomainEvent : INotification
{
  public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}
