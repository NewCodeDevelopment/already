using Core.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Data.Config.ProjectAggregateConfig;

public class ProductOptionConfig : IEntityTypeConfiguration<ProductOption>
{
    public void Configure(EntityTypeBuilder<ProductOption> builder)
    {
        // Properties
        builder.Property(x => x.Name)
            .IsRequired();


        // Relations
        builder.HasOne(x => x.Product)
            .WithMany(x => x.ProductOptions)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(x => x.Values)
            .WithOne(x => x.ProductOption)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
