using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Persistence;

public class DefaultContext : IdentityDbContext<User> {

    public DefaultContext() { }

    
    public DefaultContext(DbContextOptions<DefaultContext> options) : base(options) { }
    public DbSet<Product> Products {get;set;}

    protected override void OnModelCreating(ModelBuilder builder) {
        builder.Entity<Product>().ToTable("Products");
        base.OnModelCreating(builder);
        builder.Entity<Product>(entity => {
            entity.HasKey(prod => prod.IdProd);
            entity.Property(prod => prod.nameProd).IsRequired().HasMaxLength(120);
            entity.Property(prod => prod.descriptionProd).IsRequired().HasMaxLength(600);
            entity.Property(prod => prod.priceProd).IsRequired();
            entity.Property(prod => prod.quantityStock).IsRequired();
        });
        
        builder.HasPostgresExtension("uuid-ossp");
        builder.ApplyConfigurationsFromAssembly(typeof(DefaultContext).Assembly);
    }
    
    
}
