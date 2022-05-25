using System.Linq;
using UnitTests.Core.TestFactories.OrderAggregates;
using UnitTests.Core.TestFactories.ProductAggregates;
using Xunit;
namespace UnitTests.Core.OrderAggregate;

public class BasketTest
{
    [Fact]
    public void AddProductVariantToBasket()
    {
        var testCustomer = TestCustomerFactory.Create();
        var testProductVariant = TestProductVariantFactory.Create();
        
        testCustomer.AddProductVariantToBasket(testProductVariant);
        
        Assert.Equal(1,testCustomer.Basket.ProductVariants.Count);
        Assert.Equal(testProductVariant,testCustomer.Basket.ProductVariants.First());
    }
    
    [Fact]
    public void AddProductVariantsToBasket()
    {
        var testCustomer = TestCustomerFactory.Create();
        var testProductVariants = TestProductVariantFactory.CreateList();
        
        testCustomer.Basket.AddProductVariant(testProductVariants);
        
        Assert.Equal(testProductVariants.Count,testCustomer.Basket.ProductVariants.Count);
        Assert.Equal(testProductVariants,testCustomer.Basket.ProductVariants);
    }
    
    [Fact]
    public void RemoveProductVariantsFromBasket()
    {
        var testCustomer = TestCustomerFactory.Create();
        var testProductVariants = TestProductVariantFactory.CreateList();
        
        testCustomer.Basket.AddProductVariant(testProductVariants);

        var testProductVariant = testProductVariants.First();
        testCustomer.Basket.RemoveProductVariant(testProductVariant);
        
        Assert.Equal(testProductVariants.Count - 1,testCustomer.Basket.ProductVariants.Count);
        Assert.False(testCustomer.Basket.HasProductVariant(testProductVariant));
    }
    
    [Fact]
    public void SetCustomerToBasket()
    {
        var testCustomer = TestCustomerFactory.Create();
    
        Assert.Equal(testCustomer.Basket.Customer, testCustomer);
        Assert.NotNull(testCustomer.Basket);
    }
}
