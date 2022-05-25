using Core.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Data.Config.OrderAggregateConfig;

public class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        // Properties
        builder.Property(x => x.OrderPlacedDate)
            .IsRequired();

       
        
        
        // Relations
        builder
            .HasOne(x => x.Customer)
            .WithMany(x => x.Orders)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(x => x.OrderItems)
            .WithOne(x => x.Order)
            .IsRequired();
    }
}
