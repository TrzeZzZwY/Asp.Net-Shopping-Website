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
        builder.Entity<Transaction>().HasKey(e => e.UserId);
        builder.Entity<Transaction_Item>().HasKey(o => new { o.TransactionId, o.ItemId });
        builder.Entity<UserShoppingCart>().HasKey(e => e.UserId);
        builder.Entity<UserWishList>().HasKey(o => new { o.UserId, o.ItemId });
        builder.Entity<Item>()
            .HasMany<Category>(e => e.Categories)
            .WithMany(e => e.items);
            


        base.OnModelCreating(builder);
    }
}
