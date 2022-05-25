using Ardalis.EFCore.Extensions;
using Core.IdentityAggregate;
using Core.OrderAggregate;
using Core.ProductAggregate;
using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;

namespace Infrastructure.Data;

public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
{
    private readonly IMediator? _mediator;
    
    public AppDbContext(
        DbContextOptions<AppDbContext> options, 
        IMediator? mediator
    )
        : base(options)
    {
        _mediator = mediator;
    }
    
    
    //ApplicationUser
    public DbSet<ApplicationUser> ApplicationUsers => Set<ApplicationUser>();
    
    // OrderAggregate
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<Basket> Baskets => Set<Basket>();
    public DbSet<Customer> Customers => Set<Customer>();
    
    // ProductAggregate
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductImage> ProductImages => Set<ProductImage>();
    public DbSet<ProductVariant> ProductVariants => Set<ProductVariant>();
    public DbSet<ProductOption> ProductOptions => Set<ProductOption>();
    public DbSet<ProductOptionValue> ProductOptionValues => Set<ProductOptionValue>();

    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<Shop> Shops => Set<Shop>();
    public DbSet<Category> Categories => Set<Category>();
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    
        // Add the Postgres Extension for UUID generation
        modelBuilder.HasPostgresExtension("uuid-ossp");

        var entities = modelBuilder.Model
            .GetEntityTypes()
            .Where(w => w.ClrType.IsSubclassOf(typeof(IBaseEntity)))
            .Select(p => modelBuilder.Entity(p.ClrType));


        foreach (var entity in entities)
        {
            entity
                .Property("Id")
                .HasColumnName("Id")
                .HasColumnType("uuid")
                // .HasDefaultValueSql("uuid_generate_v4()")
                .IsRequired();

            entity
                .Property("CreatedAt")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();
        }

        modelBuilder.Entity<ApplicationUser>().ToTable("Users");
        modelBuilder.Entity<ApplicationUserRole>().ToTable("UserRoles");
        modelBuilder.Entity<ApplicationUserLogin>().ToTable("UserLogins");
        modelBuilder.Entity<ApplicationUserClaim>().ToTable("UserClaims");
        modelBuilder.Entity<ApplicationUserToken>().ToTable("UserTokens");
    
        modelBuilder.Entity<ApplicationRole>().ToTable("Roles");
        modelBuilder.Entity<ApplicationRoleClaim>().ToTable("RoleClaims");


        modelBuilder.ApplyAllConfigurationsFromCurrentAssembly();
    }

    public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<IBaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTimeOffset.Now;
                    entry.Entity.UpdatedAt = DateTimeOffset.Now;
                    break;

                case EntityState.Modified:
                    entry.Entity.UpdatedAt = DateTimeOffset.Now;
                    break;
            }
        }
        
        int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        // ignore events if no dispatcher provided
        if (_mediator == null) return result;

        // dispatch events only if save was successful
        var entitiesWithEvents = ChangeTracker.Entries<IBaseEntity>()
            .Select(e => e.Entity)
            .Where(e => e.Events.Any())
            .ToArray();

        foreach (var entity in entitiesWithEvents)
        {
            var events = entity.Events.ToArray();
            entity.Events.Clear();
            foreach (var domainEvent in events)
            {
                await _mediator.Publish(domainEvent, cancellationToken).ConfigureAwait(false);
            }
        }

        return result;
    }

    public override int SaveChanges()
    {
        return SaveChangesAsync().GetAwaiter().GetResult();
    }
}
