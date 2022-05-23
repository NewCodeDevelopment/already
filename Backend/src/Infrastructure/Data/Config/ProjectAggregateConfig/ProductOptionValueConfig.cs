using Core.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Data.Config.ProjectAggregateConfig;

public class ProductOptionValueConfig : IEntityTypeConfiguration<ProductOptionValue>
{
    public void Configure(EntityTypeBuilder<ProductOptionValue> builder)
    {
        // Properties
        builder.Property(x => x.Value)
            .IsRequired();


        // Relations
        builder.HasOne(x => x.ProductOption)
            .WithMany(x => x.Values)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(x => x.ProductVariants)
            .WithMany(x => x.ProductOptionValues);
    }
}
