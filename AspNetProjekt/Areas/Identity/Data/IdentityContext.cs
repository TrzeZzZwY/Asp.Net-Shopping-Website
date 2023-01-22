using AspNetProjekt.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspNetProjekt.Areas.Identity.Data;

public class IdentityContext : IdentityDbContext<MyUser>
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Transaction_Item> Transaction_Items { get; set; }
    public DbSet<CustomerShoppingCart> CustomersShoppingCarts { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerShoppingCart_Item> customerShoppingCart_Items { get; set; }
    public IdentityContext(DbContextOptions<IdentityContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "User", NormalizedName = "USER" }
            );

        builder.Entity<Category>().HasData(
            new Category { CategoryId = Guid.NewGuid(), CategoryName = "Pluszak" },
            new Category { CategoryId = Guid.NewGuid(), CategoryName = "Szalik" },
            new Category { CategoryId = Guid.NewGuid(), CategoryName = "Czapka" }
            );

        builder.Entity<Category>().HasKey(e => e.CategoryId);
        builder.Entity<Category>().Property(e => e.CategoryName);

        builder.Entity<Item>().HasKey(e => e.ItemId);
        builder.Entity<Item>().Property(e => e.ItemName);
        builder.Entity<Item>().Property(e => e.ItemPrice);
        builder.Entity<Item>().Property(e => e.ItemDiscount);
        builder.Entity<Item>().Property(e => e.ItemAvalibility);
        builder.Entity<Item>().Property(e => e.ItemImageName);
        builder.Entity<Item>().Property(e => e.ItemDescription);


        builder.Entity<Transaction>().HasKey(e => e.TransactionId);
        builder.Entity<Transaction>().Property(e => e.TransactionDate);

        builder.Entity<Transaction_Item>().HasKey(e => e.Transaction_ItemId);
        builder.Entity<Transaction_Item>().Property(e => e.ItemPrice);

        builder.Entity<CustomerShoppingCart_Item>().HasKey(e => e.CustomerShoppingCart_ItemId);

        builder.Entity<CustomerShoppingCart>().HasKey(e => e.CustomerId);


        builder.Entity<Customer>().HasKey(e => e.CustomerId);

        builder.Entity<Item>()
            .HasMany(e => e.Categories)
            .WithMany(e => e.items);
        builder.Entity<Item>()
           .HasMany(e => e.CustomerShoppingCart_Item)
           .WithOne(e => e.Item);
        builder.Entity<CustomerShoppingCart>()
            .HasMany(e => e.CustomerShoppingCart_Items)
            .WithOne(e => e.CustomerShoppingCart);
        builder.Entity<Item>().
            HasMany(e => e.Transaction_Items).
            WithOne(e => e.Item);
        builder.Entity<Transaction>().
            HasMany(e => e.transaction_Items)
            .WithOne(e => e.Transaction);
        builder.Entity<Item>().
            HasMany(e => e.ItemLikes)
            .WithMany(e => e.ItemLikes)
            .UsingEntity(j => j.ToTable("Item_Customer_Likes"));
        builder.Entity<Item>()
            .HasMany(e => e.CustomerWishList)
            .WithMany(e => e.CustomerWishList)
            .UsingEntity(j => j.ToTable("Item_Costomer_Wishes"));
        builder.Entity<Customer>()
            .HasOne(e => e.IdentityUser)
            .WithOne(e => e.customer)
            .HasForeignKey<Customer>(e => e.IdentityUserId);
        builder.Entity<CustomerShoppingCart>()
            .HasOne(e => e.Customer)
            .WithOne(e => e.CustomerShoppingCart);
        builder.Entity<Transaction>()
            .HasOne(e => e.Customer)
            .WithMany(e => e.Transactions);


        base.OnModelCreating(builder);
    }
}
