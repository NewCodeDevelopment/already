using System.Linq;
using UnitTests.Core.TestFactories.ProductAggregates;
using Xunit;
namespace UnitTests.Core.ProductAggregateTests;

public class ProductOptionTest
{
    [Fact]
    public void AddProductOptionValueToProductOptionConstructor()
    {
        var testProductOptionValue = TestProductOptionFactory.TestProductOptionValue;
        var testProductOption = TestProductOptionFactory.Create(testProductOptionValue);
        
        Assert.Equal(1, testProductOption.Values.Count);
        Assert.Equal(testProductOptionValue, testProductOption.Values.First());
    }
    
    [Fact]
    public void AddProductOptionValueToProductOption()
    {
        var testProductOption = TestProductOptionFactory.Create();
        var testProductOptionValue = TestProductOptionFactory.TestProductOptionValue;
        
        testProductOption.AddProductOptionValue(testProductOptionValue);
        
        Assert.Equal(2, testProductOption.Values.Count);
        Assert.Equal(testProductOptionValue, testProductOption.Values.First());
    }
    
    [Fact]
    public void SetProductToProductOption()
    {
        var testProduct = TestProductFactory.Create();
        var testProductVariants = TestProductVariantFactory.CreateList();
        
        testProduct.AddProductVariant(testProductVariants);

        foreach (var variant in testProduct.ProductVariants)
        {
            foreach (var optionValue in variant.ProductOptionValues)
            {
                var foundVariant = optionValue.ProductVariants.ToList().Find(x => x.Id == variant.Id);
                Assert.NotNull(foundVariant);
            }
        }
    }
}
