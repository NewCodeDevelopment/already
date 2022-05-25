using Core.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Data.Config.OrderAggregateConfig;

public class BasketConfig : IEntityTypeConfiguration<Basket>
{
    public void Configure(EntityTypeBuilder<Basket> builder)
    {
        // Relations
        builder
            .HasOne(x => x.Customer)
            .WithOne(x => x.Basket)
            .HasForeignKey<Basket>(x => x.CustomerId)
            .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasMany(x => x.ProductVariants);
    }
}
