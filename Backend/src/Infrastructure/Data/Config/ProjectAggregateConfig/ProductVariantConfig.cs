using Core.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Data.Config.ProjectAggregateConfig;

public class ProductVariantConfig : IEntityTypeConfiguration<ProductVariant>
{
    public void Configure(EntityTypeBuilder<ProductVariant> builder)
    {
        // Properties
        builder.Property(x => x.Price)
            .IsRequired();
        
        builder.Property(x => x.StockQuantity)
            .IsRequired();
      
        
        // Relations
        builder
            .HasOne(x => x.Product)
            .WithMany(x => x.ProductVariants)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(x => x.ProductOptionValues)
            .WithMany(x => x.ProductVariants);
    }       
}
