using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Shared;

[Keyless]
public abstract class BaseDomainEvent : INotification
{
    public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}
