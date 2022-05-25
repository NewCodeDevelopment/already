using Core.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Data.Config.OrderAggregateConfig;

public class CustomerConfig : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder
            .HasMany(x => x.Orders)
            .WithOne(x => x.Customer)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
