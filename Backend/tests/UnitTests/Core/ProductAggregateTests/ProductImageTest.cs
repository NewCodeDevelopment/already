using System.Collections.Generic;
using System.Linq;
using Core.ProductAggregate;
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
        Assert.Equal(testProductImage.ProductId, testProduct.Id);
        Assert.Equal(testProductImage.Product, testProduct);
    }
    
    [Fact]
    public void AddProductImagesToProduct()
    {
        var testProductVariant = CreateProduct.Create();
        
        testProductVariant.AddProductImage(CreateProduct.TestProductImages);
        
        Assert.Equal(CreateProduct.TestProductImages.Count, testProductVariant.ProductImages.Count);
        Assert.Equal(CreateProduct.TestProductImages, testProductVariant.ProductImages);
    }
}
