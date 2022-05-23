using System.Linq;
using UnitTests.Core.ProductAggregateTests.TestFactories;
using Xunit;
namespace UnitTests.Core.ProductAggregateTests;

public class ProductOptionTest
{
    [Fact]
    public void AddProductOptionValueToProductOptionConstructor()
    {
        var testProductOptionValue = CreateProductOption.TestProductOptionValue;
        var testProductOption = CreateProductOption.Create(testProductOptionValue);
        
        Assert.Equal(1, testProductOption.Values.Count);
        Assert.Equal(testProductOptionValue, testProductOption.Values.First());
    }
    
    [Fact]
    public void AddProductOptionValueToProductOption()
    {
        var testProductOption = CreateProductOption.Create();
        var testProductOptionValue = CreateProductOption.TestProductOptionValue;
        
        testProductOption.AddProductOptionValue(testProductOptionValue);
        
        Assert.Equal(2, testProductOption.Values.Count);
        Assert.Equal(testProductOptionValue, testProductOption.Values.First());
    }
    
    [Fact]
    public void SetProductToProductOption()
    {
        var testProduct = CreateProduct.Create();
        var testProductVariants = CreateProductVariant.CreateList();
        
        testProduct.AddProductVariant(testProductVariants);

        foreach (var variant in testProduct.ProductVariants)
        {
            foreach (var optionValue in variant.ProductOptionValues)
            {
                Assert.Equal(optionValue.ProductOption.ProductId, testProduct.Id);
                Assert.Equal(optionValue.ProductOption.Product, testProduct);
            }
        }
    }
}
