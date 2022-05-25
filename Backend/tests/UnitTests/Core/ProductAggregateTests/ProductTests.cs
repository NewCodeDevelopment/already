using System;
using System.Collections.Generic;
using System.Linq;
using Core.ProductAggregate;
using UnitTests.Core.TestFactories.ProductAggregates;
using Xunit;
namespace UnitTests.Core.ProductAggregateTests;

public class ProductTests
{
    [Fact]
    public void InitializesTitle()
    {
        var testProduct = TestProductFactory.Create();
        Assert.Equal(TestProductFactory.TestTitle, testProduct.Title);
    }
    
    [Fact]
    public void InitializesDescription()
    {
        var testProduct = TestProductFactory.Create();
        Assert.Equal(TestProductFactory.TestDescription, testProduct.Description);
    }

    [Fact]
    public void InitializesState()
    {
        var testProduct = TestProductFactory.Create();
        Assert.Equal(ProductState.Active, testProduct.State);
    }

    [Fact]
    public void InitializesProductVariant()
    {
        var testProduct = TestProductFactory.Create();
        
        Assert.Equal(1, testProduct.ProductVariants.Count);
        Assert.Equal(TestProductVariantFactory.TestPrice, testProduct.ProductVariants.First().Price);
        Assert.Equal(TestProductVariantFactory.TestQuantity, testProduct.ProductVariants.First().StockQuantity);
        Assert.Equal(testProduct.Id, testProduct.ProductVariants.First().ProductId);
    }
}
