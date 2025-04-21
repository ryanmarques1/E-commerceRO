using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using RO.DevTest.Domain.Entities;
using RO.DevTest.Persistence.Migrations;

namespace RO.DevTest.Persistence;

public class DefaultContext : IdentityDbContext<User> {

    public DefaultContext() { }

    
    public DefaultContext(DbContextOptions<DefaultContext> options) : base(options) { }
    public DbSet<Product> Products {get;set;}
    public DbSet<Sale> Sales {get;set;}

    protected override void OnModelCreating(ModelBuilder builder) {
        builder.Entity<Sale>().ToTable("Sales");
        builder.Entity<Product>().ToTable("Products");
        base.OnModelCreating(builder);
        builder.Entity<Sale>(sale => {
            sale.HasKey(s => s.IdSale);
        });

        builder.Entity<ItemSale>(itemsale => {
            itemsale.HasKey(its => its.Id);
        });
        builder.Entity<ItemSale>()
            .HasOne(i => i.Sale)
            .WithMany(s => s.Items)
            .HasForeignKey(i => i.SaleId);
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
