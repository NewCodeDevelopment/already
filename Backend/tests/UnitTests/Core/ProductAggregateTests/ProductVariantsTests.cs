using System;
using System.Collections.Generic;
using System.Linq;
using Core.ProductAggregate;
using UnitTests.Core.TestFactories.ProductAggregates;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;
namespace UnitTests.Core.ProductAggregateTests;

public class ProductVariantsTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public ProductVariantsTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void AddVariantToProject()
    {
        var testProduct = TestProductFactory.Create();
        var testProductVariant = TestProductVariantFactory.Create();

        Assert.Equal(1, testProduct.ProductVariants.Count);
        
        testProduct.AddProductVariant(testProductVariant);
        
        Assert.Equal(1, testProduct.ProductVariants.Count);
        Assert.Equal(testProductVariant, testProduct.ProductVariants.First());
    }
    
    [Fact]
    public void AddVariantsToProject()
    {
        var testProduct = TestProductFactory.Create();
        var testProductVariants = TestProductVariantFactory.CreateList();
        
        testProduct.AddProductVariant(testProductVariants);
        
        Assert.Equal(testProductVariants.Count, testProduct.ProductVariants.Count);
        Assert.Equal(testProductVariants, testProduct.ProductVariants);
    }

    [Fact]
    public void AddVariantsToInitializedProject()
    {
        var testProductVariants = TestProductVariantFactory.CreateList();
        var testProduct = TestProductFactory.Create(testProductVariants);

        Assert.Equal(testProductVariants.Count, testProduct.ProductVariants.Count);
        Assert.Equal(testProductVariants, testProduct.ProductVariants);

        foreach (var variant in testProduct.ProductVariants)
        {
            Assert.Equal(2, variant.ProductOptionValues.Count);
            Assert.Equal(variant.Product, testProduct);
        }
    }
    
    [Fact]
    public void SetProductVariantToProductOptionValue()
    {
        var testProduct = TestProductFactory.Create();
        var testProductVariant = TestProductVariantFactory.Create();
        
        testProduct.AddProductVariant(testProductVariant);
        
        foreach (var variant in testProduct.ProductVariants)
        {
            foreach (var optionValue in variant.ProductOptionValues)   
            {
                var sameVariant = optionValue.ProductVariants.ToList().Find(x => x.Id == variant.Id);
                Assert.NotNull(sameVariant);
            }
        }
    }
    
    [Fact]
    public void AddVariantWithMultipleOptionsToProject()
    {
        var testProduct = TestProductFactory.Create();
        var testProductVariants = TestProductVariantFactory.CreateList();
        
        testProduct.AddProductVariant(testProductVariants);
        
        Assert.Equal(TestProductVariantFactory.TestProductVariants.Count, testProduct.ProductVariants.Count);
        Assert.Equal(testProductVariants, testProduct.ProductVariants);
    }

    [Fact]
    public void SetProductOnProductVariant()
    {
        var testProductVariants = new List<ProductVariant>() {TestProductVariantFactory.Create()};
        var testProduct = TestProductFactory.Create(testProductVariants);

        foreach (var variant in testProduct.ProductVariants)
        {
            Assert.Equal(variant.ProductId, testProduct.Id);
            Assert.Equal(variant.Product, testProduct);
        }
    }
    
    [Fact]
    public void FailToAddVariantToProject()
    {
        var testProduct = TestProductFactory.Create();
        var action = () => testProduct.AddProductVariant((ProductVariant)null!);
    
        var exception = Assert.Throws<ArgumentNullException>(action);
        Assert.Equal("productVariant", exception.ParamName);
    }
    
    [Fact]
    public void FailToAddSameVariantToProject()
    {
        var testProduct = TestProductFactory.Create();
        var testProductVariant = TestProductVariantFactory.Create();
        testProduct.AddProductVariant(testProductVariant);
        
        testProduct.AddProductVariant(testProductVariant);
      
        Assert.Equal(1, testProduct.ProductVariants.Count);
    }
}
