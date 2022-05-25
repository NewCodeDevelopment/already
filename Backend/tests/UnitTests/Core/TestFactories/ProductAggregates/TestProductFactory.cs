using System.Collections.Generic;
using Core.ProductAggregate;

namespace UnitTests.Core.TestFactories.ProductAggregates;

public static class TestProductFactory
{
    
    // Properties
    public static readonly string TestTitle = "Coca Cola 200ml Light";
    public static readonly string TestDescription = "Dit is een product beschrijving";
    
    public static readonly Shop TestShop = new Shop("Carrefour", 7, "logoImageUrl");
    public static readonly Category TestCategory = new Category(null, "Dranken");
    public static readonly Brand TestBrand = new Brand("Coca Cola");
    
    public static readonly List<ProductImage> TestProductImages = new()
    {
        new ProductImage("imageUlr", "een foto van een brug"),
        new ProductImage("imageUlr", "een foto van een brug"),
        new ProductImage("imageUlr", "een foto van een brug"),
    };

   
    
    // Creating Methods
    public static Product Create()
    {
        return new Product(TestTitle, TestDescription, TestBrand, TestCategory, TestShop, new ProductVariant(TestProductVariantFactory.TestPrice, TestProductVariantFactory.TestQuantity));
    }
    
    public static Product Create(List<ProductVariant> productVariants)
    {
        return new Product(TestTitle, TestDescription, TestBrand, TestCategory, TestShop, productVariants);
    }
}
