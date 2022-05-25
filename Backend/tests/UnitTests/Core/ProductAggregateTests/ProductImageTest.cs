using System.Collections.Generic;
using System.Linq;
using Core.ProductAggregate;
using UnitTests.Core.TestFactories.ProductAggregates;
using Xunit;
namespace UnitTests.Core.ProductAggregateTests;

public class ProductImageTest
{
    [Fact]
    public void AddProductImageToProduct()
    {
        var testProduct = TestProductFactory.Create();
        var testProductImage = TestProductFactory.TestProductImages.First();
        
        testProduct.AddProductImage(testProductImage);
        
        Assert.Equal(1, testProduct.ProductImages.Count);
        Assert.Equal(TestProductFactory.TestProductImages.First(), testProduct.ProductImages.First());
    }
    
    [Fact]
    public void AddProductImagesToProduct()
    {
        var testProduct = TestProductFactory.Create();
        testProduct.AddProductImage(TestProductFactory.TestProductImages);
        
        Assert.Equal(TestProductFactory.TestProductImages.Count, testProduct.ProductImages.Count);
        Assert.Equal(TestProductFactory.TestProductImages, testProduct.ProductImages);
    }

    [Fact]
    public void SetProductToProductImage()
    {
        var testProduct = TestProductFactory.Create();
        var testProductImage = TestProductFactory.TestProductImages.First();
        
        testProduct.AddProductImage(testProductImage);
        
        Assert.Equal(testProductImage.ProductId, testProduct.Id);
        Assert.Equal(testProductImage.Product, testProduct);
    }
}
