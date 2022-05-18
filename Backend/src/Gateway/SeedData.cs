using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Shared;
namespace Gateway;

public static class SeedData
{
    public static int countOfSeedData = 10;
  
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var dbContext = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
        {
            if (dbContext.Products.Any())
            {
                return;   // DB has been seeded
            }
      
            PopulateTestData(dbContext);
        }
    }
    public static void PopulateTestData(AppDbContext dbContext)
    {
        // RemoveFromDb(dbContext, dbContext.Channels);
        // RemoveFromDb(dbContext, dbContext.Prospects);
        // RemoveFromDb(dbContext, dbContext.Tags);
        //
        //
        // RemoveFromDb(dbContext, dbContext.Categories);
        // RemoveFromDb(dbContext, dbContext.SubCategories);
        //
        // RemoveFromDb(dbContext, dbContext.Agreements);
        // RemoveFromDb(dbContext, dbContext.SubAgreements);
        //
        // RemoveFromDb(dbContext, dbContext.Projects);
        // RemoveFromDb(dbContext, dbContext.SubProjects);
        //
        // dbContext.SaveChanges();

        // var channelSeedData = CreateChannelSeedData(countOfSeedData);
        // var categorySeedData = CreateCategorySeedData(countOfSeedData);
        // var agreementSeedData = CreateAgreementSeedData(countOfSeedData, categorySeedData);
        // var projectSeedData = CreateProjectSeedData(countOfSeedData, categorySeedData, agreementSeedData);
    
        // dbContext.Channels.AddRange(channelSeedData);
        // dbContext.Categories.AddRange(categorySeedData);
        // dbContext.Agreements.AddRange(agreementSeedData);
        //  dbContext.Projects.AddRange(projectSeedData);
    
        // dbContext.SaveChanges();
    }

  
  
    private static void RemoveFromDb<T>(AppDbContext dbContext, DbSet<T> entities) where T: BaseEntity
    {
        foreach (var item in entities)
        {
            dbContext.Remove(item);
        }
    }
}
