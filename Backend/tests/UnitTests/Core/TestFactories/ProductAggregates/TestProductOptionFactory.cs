using System.Collections.Generic;
using Core.ProductAggregate;
namespace UnitTests.Core.TestFactories.ProductAggregates;

public static class TestProductOptionFactory
{
    
    // Properties
    public static readonly string TestOption = "Color";
    public static readonly ProductOptionValue TestProductOptionValue = new("Yellow");
    
    public static readonly List<ProductOption> TestProductOptions = new()
    {
        new ProductOption("Color", new ProductOptionValue("Yellow")),
        new ProductOption("Size", new ProductOptionValue("Big")),
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
    
    
    // Creating Methods
    public static ProductOption Create()
    {
        return new ProductOption(TestOption, TestProductOptionValue);
    }
    
    public static ProductOption Create(ProductOptionValue productOptionValue)
    {
        return new ProductOption(TestOption, productOptionValue);
    }
    
    public static ProductOption Create(List<ProductOptionValue> productOptionValues)
    {
        return new ProductOption(TestOption, productOptionValues);
    }
    
    public static List<ProductOption> CreateList()
    {
        return TestProductOptions;

    }
}
