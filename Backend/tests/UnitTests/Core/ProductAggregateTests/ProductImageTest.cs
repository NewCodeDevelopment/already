using System.Collections.Generic;
using System.Linq;
using Core.ProductAggregate;
using UnitTests.Core.ProductAggregateTests.TestFactories;
using Xunit;
namespace UnitTests.Core.ProductAggregateTests;

public class ProductImageTest
{
    [Fact]
    public void AddProductImageToProduct()
    {
        var testProduct = CreateProduct.Create();
        var testProductImage = CreateProduct.TestProductImages.First();
        
        testProduct.AddProductImage(testProductImage);
        
        Assert.Equal(1, testProduct.ProductImages.Count);
        Assert.Equal(CreateProduct.TestProductImages.First(), testProduct.ProductImages.First());
    }
    
    [Fact]
    public void AddProductImagesToProduct()
    {
        var testProduct = CreateProduct.Create();
        testProduct.AddProductImage(CreateProduct.TestProductImages);
        
        Assert.Equal(CreateProduct.TestProductImages.Count, testProduct.ProductImages.Count);
        Assert.Equal(CreateProduct.TestProductImages, testProduct.ProductImages);
    }

    [Fact]
    public void SetProductToProductImage()
    {
        var testProduct = CreateProduct.Create();
        var testProductImage = CreateProduct.TestProductImages.First();
        
        testProduct.AddProductImage(testProductImage);
        
        Assert.Equal(testProductImage.ProductId, testProduct.Id);
        Assert.Equal(testProductImage.Product, testProduct);
    }
}
