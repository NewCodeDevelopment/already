namespace Shared.Interfaces;

public interface IBaseEntity
{
    public Guid Id { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }

    public List<BaseDomainEvent> Events { get; }
}
