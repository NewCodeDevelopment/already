using Ardalis.Specification;

namespace Shared.Interfaces;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}
