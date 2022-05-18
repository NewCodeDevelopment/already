using Ardalis.Specification;

namespace Shared.Interfaces;

// from Ardalis.Specification
public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}
