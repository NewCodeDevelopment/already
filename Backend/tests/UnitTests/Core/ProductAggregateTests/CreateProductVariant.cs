using System.Collections.Generic;
using System.Linq;
using Core.ProductAggregate;
namespace UnitTests.Core.ProductAggregateTests;

public static class CreateProductVariant
{
    public static readonly double TestPrice = 50;
    public static readonly int TestQuantity = 25;

    public static readonly ProductVariant TestProductVariant = new ProductVariant(
        TestPrice,
        TestQuantity,
        CreateProductOption.Create().Values.First());
    
    public static readonly List<ProductVariant> TestProductVariants = new()
    {
        new ProductVariant(TestPrice, TestQuantity, new List<ProductOptionValue>()
        {
            CreateProductOption.TestProductOptions[2].Values.First(),
            CreateProductOption.TestProductOptions[3].Values.First()
        }),
        new ProductVariant(TestPrice, TestQuantity, new List<ProductOptionValue>()
        {
            CreateProductOption.TestProductOptions[2].Values.First(),
            CreateProductOption.TestProductOptions[3].Values.Last()
        }),
        new ProductVariant(TestPrice, TestQuantity, new List<ProductOptionValue>()
        {
            CreateProductOption.TestProductOptions[2].Values.Last(),
            CreateProductOption.TestProductOptions[3].Values.First()
        }),
        new ProductVariant(TestPrice, TestQuantity, new List<ProductOptionValue>()
        {
            CreateProductOption.TestProductOptions[2].Values.Last(),
            CreateProductOption.TestProductOptions[3].Values.Last()
        }),
    };

    public static ProductVariant Create()
    {
        return TestProductVariants.First();

    }
    
    
    public static List<ProductVariant> CreateList()
    {
        return TestProductVariants;

    }
}
