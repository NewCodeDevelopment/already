using System.Collections.Generic;
using System.Linq;
using Core.ProductAggregate;
namespace UnitTests.Core.TestFactories.ProductAggregates;

public static class TestProductVariantFactory
{
    
    // Properties
    public static readonly double TestPrice = 50;
    public static readonly int TestQuantity = 25;

    public static List<ProductVariant> TestProductVariants = new()
    {
        new ProductVariant(TestPrice, TestQuantity, new List<ProductOptionValue>()
        {
            TestProductOptionFactory.TestProductOptions[2].Values.First(),
            TestProductOptionFactory.TestProductOptions[3].Values.First()
        }),
        new ProductVariant(TestPrice, TestQuantity, new List<ProductOptionValue>()
        {
            TestProductOptionFactory.TestProductOptions[2].Values.First(),
            TestProductOptionFactory.TestProductOptions[3].Values.Last()
        }),
        new ProductVariant(TestPrice, TestQuantity, new List<ProductOptionValue>()
        {
            TestProductOptionFactory.TestProductOptions[2].Values.Last(),
            TestProductOptionFactory.TestProductOptions[3].Values.First()
        }),
        new ProductVariant(TestPrice, TestQuantity, new List<ProductOptionValue>()
        {
            TestProductOptionFactory.TestProductOptions[2].Values.Last(),
            TestProductOptionFactory.TestProductOptions[3].Values.Last()
        }),
    };

    
    
    // Creating Methods
    public static ProductVariant Create()
    {
        return new ProductVariant(TestPrice, TestQuantity);
    }
    
    public static List<ProductVariant> CreateList()
    {
        return TestProductVariants;
    }
}
