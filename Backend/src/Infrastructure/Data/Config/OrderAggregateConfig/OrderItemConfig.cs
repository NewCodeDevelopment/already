using Core.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Data.Config.OrderAggregateConfig;

public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        // Relations
        builder
            .HasOne(x => x.Order)
            .WithMany(x => x.OrderItems);

        builder
            .HasOne(x => x.ProductVariant);
    }
}
