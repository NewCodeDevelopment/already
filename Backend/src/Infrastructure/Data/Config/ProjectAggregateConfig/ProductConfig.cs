using Core.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Data.Config.ProjectAggregateConfig;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        //Properties
        builder.Property(x => x.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Description)
            .IsRequired();

        builder.Property(x => x.State)
            .HasDefaultValue(ProductState.Active)
            .HasConversion<string>()
            .IsRequired();


        // Relations
        builder
            .HasOne(x => x.Brand)
            .WithMany(x => x.Products)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder
            .HasOne(x => x.Category)
            .WithMany(x => x.Products)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder
            .HasOne(x => x.Shop)
            .WithMany(x => x.Products)
            .OnDelete(DeleteBehavior.SetNull);
        
        
        // Product options
        builder
            .HasMany(x => x.ProductVariants)
            .WithOne(x => x.Product)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .HasMany(x => x.ProductImages)
            .WithOne(x => x.Product)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .HasMany(x => x.ProductOptions)
            .WithOne(x => x.Product)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
