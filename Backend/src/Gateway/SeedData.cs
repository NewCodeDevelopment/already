using Core.ProductAggregate;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Shared;
namespace Gateway;

public static class SeedData
{
    public static int countOfSeedData = 5;

    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var dbContext = new AppDbContext(
                   serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(),
                   null))
        {
            if (dbContext.Products.Any())
            {
                return; // DB has been seeded
            }

            PopulateTestData(dbContext);
        }
    }

    public static void PopulateTestData(AppDbContext dbContext)
    {
        // Deleting Data
        RemoveFromDb(dbContext, dbContext.Shops);
        RemoveFromDb(dbContext, dbContext.Categories);
        RemoveFromDb(dbContext, dbContext.Brands);
        
        RemoveFromDb(dbContext, dbContext.Products);
        RemoveFromDb(dbContext, dbContext.ProductVariants);
        RemoveFromDb(dbContext, dbContext.ProductImages);

        dbContext.SaveChanges();
        
        
        // Adding Data
        dbContext.Products.AddRange(SeedProducts);
       

        dbContext.SaveChanges();
    }
    
      public static readonly Shop[] SeedShops = new Shop[5]
      {
          new Shop("Carrefour", 7, "logoImageUrl"),
          new Shop("Aldi", 5, "logoImageUrl"),
          new Shop("Lidl", 3, "logoImageUrl"),
          new Shop("Albert Hein", 2, "logoImageUrl"),
          new Shop("Jumbo", 1, "logoImageUrl"),
      };
    
      public static readonly Category[] SeedCategories = new Category [5]{
    
          new Category(null, "Dranken"),
          new Category(null, "Vis en Vlees"),
          new Category(null, "Zuivel"),
          new Category(null, "Ontbijtgranen"),
          new Category(null, "Noten en Zaden"),
      };
    
    public static readonly Brand[] SeedBrands = new Brand[5]
      {
          new Brand("Coca Cola"),    
          new Brand("Fanta"),    
          new Brand("Sprite"),    
          new Brand("Everyday"),    
          new Brand("Lipton"),
      };

    public static readonly ProductOptionValue[] SeedProductOptionValues =
    {
        new ProductOptionValue("S"),
        new ProductOptionValue("M"),
        new ProductOptionValue("Rubber"),
        new ProductOptionValue("Metal"),
    };
    
    public static readonly ProductOption[] SeedProductOptions = new ProductOption[5]
    {
        new ProductOption("Color", "Yellow"),
        new ProductOption("Size", "Big"),
        new ProductOption("Color", new List<ProductOptionValue>()
        {
            new ProductOptionValue("Yellow"),
            new ProductOptionValue("Blue"),
            new ProductOptionValue("Orange"),
        }),
        new ProductOption("Size", new List<ProductOptionValue>()
        {
            SeedProductOptionValues[0],
            SeedProductOptionValues[1],
        }),
        new ProductOption("Material", new List<ProductOptionValue>()
        {
            SeedProductOptionValues[2],
            SeedProductOptionValues[3],

        }),
    };

    public static readonly ProductVariant[] SeedProductVariants = new ProductVariant[4]
    {
        new ProductVariant( 20, 50, SeedProductOptions[0].Values.First()),
        new ProductVariant( 20, 60, SeedProductOptions[1].Values.First()),
        new ProductVariant( 5, 30, SeedProductOptions[2].Values.First()),
        new ProductVariant( 5, 30, SeedProductOptions[3].Values.First()),
    };  
    
    
    public static readonly Product[] SeedProducts =
    {
        new Product(
            "Coca Cola 200ml Light",
            "Dit is een product beschrijving",
            SeedBrands[0],
            SeedCategories[0],
            SeedShops[0],
            SeedProductVariants[0].Price,
            SeedProductVariants[0].Quantity),
        new Product(
            "Coca Cola 200ml Light",
            "Dit is een product beschrijving",
            SeedBrands[1],
            SeedCategories[1],
            SeedShops[1],
            SeedProductVariants[1].Price,
            SeedProductVariants[1].Quantity),
        new Product(
            "Coca Cola 200ml Light",
            "Dit is een product beschrijving",
            SeedBrands[2],
            SeedCategories[2],
            SeedShops[2],
            SeedProductVariants[2].Price,
            SeedProductVariants[2].Quantity),
        new Product(
            "Coca Cola 200ml Light",
            "Dit is een product beschrijving",
            SeedBrands[3],
            SeedCategories[3],
            SeedShops[3],
            SeedProductVariants[3].Price,
            SeedProductVariants[3].Quantity),
        // new Product(
        //     "Coca Cola 200ml Light",
        //     "Dit is een product beschrijving",
        //     SeedBrands[4],
        //     SeedCategories[4],
        //     SeedShops[4],
        //     new List<ProductVariant>()
        //     {
        //         new ProductVariant( 40, 90, new List<ProductOptionValue>()
        //         {
        //             SeedProductOptions[3].Values.First(),
        //             SeedProductOptions[4].Values.First(),
        //         }),
        //         // new ProductVariant( 40, 90, new List<ProductOptionValue>()
        //         // {
        //         //     SeedProductOptionValues[0],
        //         //     SeedProductOptionValues[3],
        //         // }),
        //         // new ProductVariant( 40, 90, new List<ProductOptionValue>()
        //         // {
        //         //     SeedProductOptionValues[1],
        //         //     SeedProductOptionValues[2],
        //         // }),
        //         // new ProductVariant( 40, 90, new List<ProductOptionValue>()
        //         // {
        //         //     SeedProductOptionValues[1],
        //         //     SeedProductOptionValues[3],
        //         // }),
        //     }),
    };


    
    
    
    // Removing
    private static void RemoveFromDb<T>(AppDbContext dbContext, DbSet<T> entities) where T: BaseEntity
    {
        foreach (var item in entities)
        {
            dbContext.Remove(item);
        }
    }
}
