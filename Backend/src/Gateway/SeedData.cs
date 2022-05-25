using Core.OrderAggregate;
using Core.ProductAggregate;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Shared;
using Shared.Interfaces;
using Shared.Logger;
namespace Gateway;

public class SeedDataLog{}

public static class SeedData
{
    
    public static string Initialize(IServiceProvider serviceProvider)
    {
        using (var dbContext = new AppDbContext(
                   serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(),
                   null))
        {
            if (dbContext.Products.Any())
            {
                return "DB  has already been seeded"; // DB has been seeded
            }

            PopulateTestData(dbContext);
            return "Successfully seeded";
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
        
        RemoveFromDb(dbContext, dbContext.Orders);
        RemoveFromDb(dbContext, dbContext.OrderItems);
        // RemoveFromDb(dbContext, dbContext.Customers);
        RemoveFromDb(dbContext, dbContext.Baskets);

        dbContext.SaveChanges();
        
        // Adding Product Data
        dbContext.Products.AddRange(SeedProducts);
        
        // Adding Order Data
        for (int i = 0; i < SeedCustomers.Length; i++)
        {
            SeedCustomers[i].AddOrder(SeedOrders[i]);
        }
        dbContext.Customers.AddRange(SeedCustomers);

        dbContext.SaveChanges();
    }
    
    
    
    
    // ProductAggregate SeedData
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

    
    
    
    
    
    // OrderAggregate SeedData
    public static readonly Customer[] SeedCustomers = new Customer[5]
    {
        new Customer("Burak", "Gozen","burakgozen38@gmail.com"),
        new Customer("Omer", "Altin","omer.altin@gmail.com"),
        new Customer("Efekan", "Horzun","efekan.horzum@gmail.com"),
        new Customer("Hakan", "Gokalp","hakan.gokalp@gmail.com"),
        new Customer("Bedirhan", "Bel","bedirhan.bel@gmail.com"),
    };
    
    public static readonly Order[] SeedOrders = new Order[5]
    {
        new Order(new List<OrderItem>()
        {
            new OrderItem(10,SeedProducts[0].ProductVariants.First()),
        }),
        new Order(new List<OrderItem>()
        {
            new OrderItem(10,SeedProducts[1].ProductVariants.First()),

        }),
        new Order(new List<OrderItem>()
        {
            new OrderItem(10,SeedProducts[2].ProductVariants.First()),

        }),
        new Order(new List<OrderItem>()
        {
            new OrderItem(10,SeedProducts[3].ProductVariants.First()),

        }),
        new Order(new List<OrderItem>()
        {
            new OrderItem(10,SeedProducts[4].ProductVariants.First()),

        }),
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
