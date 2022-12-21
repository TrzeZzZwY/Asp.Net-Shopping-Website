using AspNetProjekt.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspNetProjekt.Areas.Identity.Data;

public class IdentityContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<ItemLikes> ItemsLikes { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Transaction_Item> Transaction_Items { get; set; }
    public DbSet<UserShoppingCart> UsersShoppingCarts { get; set; }
    public DbSet<UserWishList> UsersWishLists { get; set; }
    public IdentityContext(DbContextOptions<IdentityContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Category>().HasData(
            new Category { CategoryId = Guid.NewGuid(), CategoryName = "Pluszak" },
            new Category { CategoryId = Guid.NewGuid(), CategoryName = "Szalik" },
            new Category { CategoryId = Guid.NewGuid(), CategoryName = "Czapka" }
            );
        builder.Entity<Category>().HasKey(e => e.CategoryId);
        builder.Entity<Item>().HasKey(e => e.ItemId);
        builder.Entity<ItemLikes>().HasKey(o => new { o.UserId, o.ItemId });
        builder.Entity<Transaction>().HasKey(e => e.TransactionId);
        builder.Entity<Transaction_Item>().HasKey(o => new { o.TransactionId, o.ItemId });
        builder.Entity<UserShoppingCart>().HasKey(e => e.UserId);
        builder.Entity<UserWishList>().HasKey(o => new { o.UserId, o.ItemId });
        builder.Entity<Item>()
            .HasMany(e => e.Categories)
            .WithMany(e => e.items);
        builder.Entity<UserShoppingCart>()
            .HasMany(e => e.Items)
            .WithMany(e => e.userShoppingCarts);
        builder.Entity<Item>().
            HasMany(e => e.transaction_Items).
            WithOne(e => e.Item);
        builder.Entity<Transaction>().
            HasMany(e => e.transaction_Items)
            .WithOne(e => e.Transaction);
        builder.Entity<Item>().
            HasMany(e => e.ItemLikes)
            .WithOne(e => e.Item);
        builder.Entity<Item>()
            .HasMany(e => e.userWishLists)
            .WithOne(e => e.Item);

        base.OnModelCreating(builder);
    }
}
