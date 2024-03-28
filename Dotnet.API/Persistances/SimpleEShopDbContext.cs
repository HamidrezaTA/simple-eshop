using api.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dotnet.API.Persistances;

public class SimpleEShopDbContext : IdentityDbContext<User, Role, long>
{
    public SimpleEShopDbContext(DbContextOptions options) : base(options)
    {
    }

    protected SimpleEShopDbContext()
    {
    }

    public DbSet<Address> Addresses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<StoredFile> PersistFiles { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductSpecification> ProductSpecs { get; set; }
    public DbSet<Specification> Specifications { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    public override int SaveChanges()
    {
        SetCreateAtAndUpdateAt();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetCreateAtAndUpdateAt();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void SetCreateAtAndUpdateAt()
    {
        var entities = ChangeTracker.Entries()
                    .Where(x => x.Entity is BaseEntity<long> && (x.State == EntityState.Added || x.State == EntityState.Modified));

        var currentTime = DateTimeOffset.UtcNow;

        foreach (var entityEntry in entities)
        {
            if (entityEntry.State == EntityState.Added)
            {
                ((BaseEntitySoftDelete<long>)entityEntry.Entity).CreatedAt = currentTime;
            }

            ((BaseEntitySoftDelete<long>)entityEntry.Entity).UpdatedAt = currentTime;
        }
    }
}
