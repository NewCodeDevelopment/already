using System;
using System.Linq;
using Core.ProductAggregate;
using Xunit;
using Xunit.Sdk;
namespace UnitTests.Core.ProductAggregateTests;

public class ProductVariantsTests
{
    [Fact]
    public void AddVariantToProject()
    {
        var testProduct = CreateProduct.Create();
        var testProductVariant = CreateProductVariant.Create();

        Assert.Equal(1, testProduct.ProductVariants.Count);
        
        testProduct.AddProductVariant(testProductVariant);
        
        Assert.Equal(1, testProduct.ProductVariants.Count);
        Assert.Equal(testProductVariant, testProduct.ProductVariants.First());

        foreach (var variant in testProduct.ProductVariants)
        {
            Assert.Equal(variant.Product, testProduct);
        }
    }
    
    [Fact]
    public void AddVariantWithMultipleOptionsToProject()
    {
        var testProduct = CreateProduct.Create();
        var testProductVariants = CreateProductVariant.CreateList();
        
        testProduct.AddProductVariant(testProductVariants);
        
        Assert.Equal(CreateProductVariant.TestProductVariants.Count, testProduct.ProductVariants.Count);
        Assert.Equal(testProductVariants, testProduct.ProductVariants);

        foreach (var variant in testProduct.ProductVariants)
        {
            Assert.Equal(2, variant.ProductOptionValues.Count);
            Assert.Equal(variant.Product, testProduct);
        }
    }
    
    [Fact]
    public void FailToAddVariantToProject()
    {
        var testProduct = CreateProduct.Create();
        var action = () => testProduct.AddProductVariant((ProductVariant)null!);
    
        var exception = Assert.Throws<ArgumentNullException>(action);
        Assert.Equal("productVariant", exception.ParamName);
    }
    
    [Fact]
    public void FailToAddSameVariantToProject()
    {
        var testProduct = CreateProduct.Create();
        var testProductVariant = CreateProductVariant.Create();
        testProduct.AddProductVariant(testProductVariant);
        
        testProduct.AddProductVariant(testProductVariant);
      
        Assert.Equal(1, testProduct.ProductVariants.Count);
    }
    
    [Fact]
    public void AddVariantsToProject()
    {
        var testProduct = CreateProduct.Create();
        var testProductVariants = CreateProductVariant.CreateList();
        
        testProduct.AddProductVariant(testProductVariants);
        
        Assert.Equal(testProductVariants.Count, testProduct.ProductVariants.Count);
        Assert.Equal(testProductVariants, testProduct.ProductVariants);
    }
    
    [Fact]
    public void AddVariantsToInitializedProject()
    {
        var testProductVariants = CreateProductVariant.CreateList();
        var testProduct = CreateProduct.Create(testProductVariants);

        Assert.Equal(testProductVariants.Count, testProduct.ProductVariants.Count);
        Assert.Equal(testProductVariants, testProduct.ProductVariants);
    }
}
