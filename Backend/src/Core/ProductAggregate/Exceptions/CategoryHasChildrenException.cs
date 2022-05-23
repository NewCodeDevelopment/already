namespace Core.ProductAggregate.Exceptions;

public class CategoryHasChildrenException : Exception
{
    public CategoryHasChildrenException() :base("Cannot perform action, because this category has subcategories.") {}
    //
    // public CategoryHasChildrenException(string message) : base(message) {}
    //
    // public CategoryHasChildrenException(string message, Exception inner) : base(message, inner) {}
}
