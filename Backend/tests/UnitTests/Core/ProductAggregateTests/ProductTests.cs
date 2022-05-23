using System;
using System.Collections.Generic;
using System.Linq;
using Core.ProductAggregate;
using Xunit;
namespace UnitTests.Core.ProductAggregateTests;

public class ProductTests
{
    [Fact]
    public void InitializesTitle()
    {
        var testProduct = CreateProduct.Create();
        Assert.Equal(CreateProduct.TestTitle, testProduct.Title);
    }
    
    [Fact]
    public void InitializesDescription()
    {
        var testProduct = CreateProduct.Create();
        Assert.Equal(CreateProduct.TestDescription, testProduct.Description);
    }

    [Fact]
    public void InitializesProductVariant()
    {
        var testProduct = CreateProduct.Create();
        Assert.Equal(1, testProduct.ProductVariants.Count);
        Assert.Equal(CreateProductVariant.TestPrice, testProduct.ProductVariants.First().Price);
        Assert.Equal(CreateProductVariant.TestQuantity, testProduct.ProductVariants.First().Quantity);
        Assert.Equal(testProduct.Id, testProduct.ProductVariants.First().ProductId);
    }
}
