using System.Collections.Generic;
using System.Linq;
using Core.ProductAggregate;
namespace UnitTests.Core.ProductAggregateTests;

public class CreateProductOption
{
    public static readonly List<ProductOption> TestProductOptions = new List<ProductOption>()
    {
        new ProductOption("Color", "Yellow"),
        new ProductOption("Size", "Big"),
        new ProductOption(
            "Color",
            new List<ProductOptionValue>()
            {
                new ProductOptionValue("Yellow"),
                new ProductOptionValue("Blue"),
            }),
        new ProductOption(
            "Size",
            new List<ProductOptionValue>()
            {
                new ProductOptionValue("S"),
                new ProductOptionValue("M"),
            }),
    };
    
    public static ProductOption Create()
    {
        return TestProductOptions.First();
    }
    
    public static List<ProductOption> CreateList()
    {
        return TestProductOptions;

    }
}
