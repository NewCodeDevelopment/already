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


        foreach (var product in SeedProducts)
        {
            Console.WriteLine(product.Id.ToString());

            foreach (var variant in product.ProductVariants)
            {
                Console.WriteLine("\t" + variant.ProductId);

                foreach (var option in variant.ProductOptionValues)
                {
                    Console.WriteLine("\t" + option.ProductOption.ProductId);
                }
            }
        }
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

    public static readonly ProductOption[] SeedProductOptions = new ProductOption[2]
    {
        new ProductOption("Size", new List<ProductOptionValue>()
        {
            new ProductOptionValue("S"),
            new ProductOptionValue("M"),
        }),
        new ProductOption("Material", new List<ProductOptionValue>()
        {
            new ProductOptionValue("Rubber"),
            new ProductOptionValue("Metal"),
        }),
    };


    public static readonly Product[] SeedProducts =
    {
        new Product(
            "Coca Cola 200ml Light",
            "Dit is een product beschrijving",
            SeedBrands[0],
            SeedCategories[0],
            SeedShops[0],
            new ProductVariant(20,80)),
        new Product(
            "Coca Cola 200ml Light",
            "Dit is een product beschrijving",
            SeedBrands[1],
            SeedCategories[1],
            SeedShops[1],
            new ProductVariant(30,50)),
        new Product(
            "Coca Cola 200ml Light",
            "Dit is een product beschrijving",
            SeedBrands[2],
            SeedCategories[2],
            SeedShops[2],
            new ProductVariant(50,60)),
        new Product(
            "Coca Cola 200ml Light",
            "Dit is een product beschrijving",
            SeedBrands[3],
            SeedCategories[3],
            SeedShops[3],
            new ProductVariant(10,90)),
        new Product(
            "Coca Cola 200ml Light",
            "Dit is een product beschrijving",
            SeedBrands[4],
            SeedCategories[4],
            SeedShops[4],
            new List<ProductVariant>()
            {
                new ProductVariant( 40, 90, new List<ProductOptionValue>()
                {
                    SeedProductOptions[0].Values.First(),
                    SeedProductOptions[1].Values.First(),
                }),
                new ProductVariant( 40, 90, new List<ProductOptionValue>()
                {
                    SeedProductOptions[0].Values.First(),
                    SeedProductOptions[1].Values.Last(),
                }),
                new ProductVariant( 40, 90, new List<ProductOptionValue>()
                {
                    SeedProductOptions[0].Values.Last(),
                    SeedProductOptions[1].Values.First(),
                }),
                new ProductVariant( 40, 90, new List<ProductOptionValue>()
                {
                    SeedProductOptions[0].Values.Last(),
                    SeedProductOptions[1].Values.Last(),
                }),
            })
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
