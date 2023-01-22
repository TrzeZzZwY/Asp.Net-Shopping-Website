﻿// <auto-generated />
using System;
using AspNetProjekt.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AspNetProjekt.Migrations
{
    [DbContext(typeof(IdentityContext))]
    [Migration("20230122185735_likes_and_wishes")]
    partial class likes_and_wishes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AspNetProjekt.Models.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("201a50b9-2b0d-4d31-9228-bf0a76a278b2"),
                            CategoryName = "Pluszak"
                        },
                        new
                        {
                            CategoryId = new Guid("414d95f5-765b-407e-8c32-bcba94adc248"),
                            CategoryName = "Szalik"
                        },
                        new
                        {
                            CategoryId = new Guid("d9f868c2-3d98-4320-8f86-93158c25db1f"),
                            CategoryName = "Czapka"
                        });
                });

            modelBuilder.Entity("AspNetProjekt.Models.Customer", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerShoppingCartsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CustomerId");

                    b.HasIndex("IdentityUserId")
                        .IsUnique()
                        .HasFilter("[IdentityUserId] IS NOT NULL");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("AspNetProjekt.Models.CustomerShoppingCart", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CustomerId");

                    b.ToTable("CustomersShoppingCarts");
                });

            modelBuilder.Entity("AspNetProjekt.Models.CustomerShoppingCart_Item", b =>
                {
                    b.Property<Guid>("CustomerShoppingCart_ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerShoppingCartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CustomerShoppingCart_ItemId");

                    b.HasIndex("CustomerShoppingCartId");

                    b.HasIndex("ItemId");

                    b.ToTable("customerShoppingCart_Items");
                });

            modelBuilder.Entity("AspNetProjekt.Models.Item", b =>
                {
                    b.Property<Guid>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ItemAvalibility")
                        .HasColumnType("int");

                    b.Property<string>("ItemDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemDiscount")
                        .HasColumnType("int");

                    b.Property<string>("ItemImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ItemPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ItemId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("AspNetProjekt.Models.MyUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("AspNetProjekt.Models.Transaction", b =>
                {
                    b.Property<Guid>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TransactionId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("AspNetProjekt.Models.Transaction_Item", b =>
                {
                    b.Property<Guid>("Transaction_ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ItemPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("TransactionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Transaction_ItemId");

                    b.HasIndex("ItemId");

                    b.HasIndex("TransactionId");

                    b.ToTable("Transaction_Items");
                });

            modelBuilder.Entity("CategoryItem", b =>
                {
                    b.Property<Guid>("CategoriesCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("itemsItemId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoriesCategoryId", "itemsItemId");

                    b.HasIndex("itemsItemId");

                    b.ToTable("CategoryItem");
                });

            modelBuilder.Entity("CustomerItem", b =>
                {
                    b.Property<Guid>("ItemLikesCustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemLikesItemId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ItemLikesCustomerId", "ItemLikesItemId");

                    b.HasIndex("ItemLikesItemId");

                    b.ToTable("CustomerItem");
                });

            modelBuilder.Entity("CustomerItem1", b =>
                {
                    b.Property<Guid>("CustomerWishListCustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerWishListItemId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CustomerWishListCustomerId", "CustomerWishListItemId");

                    b.HasIndex("CustomerWishListItemId");

                    b.ToTable("CustomerItem1");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "2121f5e9-19df-45cc-a43d-737f1cf7bae4",
                            ConcurrencyStamp = "cf9ce213-00c5-4e3d-a3bf-2a8a9658b038",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "4f25d739-730c-4cc1-b514-322e74338ac7",
                            ConcurrencyStamp = "1d2e4513-f5b4-40f8-91ac-7fb23003b787",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("AspNetProjekt.Models.Customer", b =>
                {
                    b.HasOne("AspNetProjekt.Models.MyUser", "IdentityUser")
                        .WithOne("customer")
                        .HasForeignKey("AspNetProjekt.Models.Customer", "IdentityUserId");

                    b.Navigation("IdentityUser");
                });

            modelBuilder.Entity("AspNetProjekt.Models.CustomerShoppingCart", b =>
                {
                    b.HasOne("AspNetProjekt.Models.Customer", "Customer")
                        .WithOne("CustomerShoppingCart")
                        .HasForeignKey("AspNetProjekt.Models.CustomerShoppingCart", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("AspNetProjekt.Models.CustomerShoppingCart_Item", b =>
                {
                    b.HasOne("AspNetProjekt.Models.CustomerShoppingCart", "CustomerShoppingCart")
                        .WithMany("CustomerShoppingCart_Items")
                        .HasForeignKey("CustomerShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AspNetProjekt.Models.Item", "Item")
                        .WithMany("CustomerShoppingCart_Item")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerShoppingCart");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("AspNetProjekt.Models.Transaction", b =>
                {
                    b.HasOne("AspNetProjekt.Models.Customer", "Customer")
                        .WithMany("Transactions")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("AspNetProjekt.Models.Transaction_Item", b =>
                {
                    b.HasOne("AspNetProjekt.Models.Item", "Item")
                        .WithMany("Transaction_Items")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AspNetProjekt.Models.Transaction", "Transaction")
                        .WithMany("transaction_Items")
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("CategoryItem", b =>
                {
                    b.HasOne("AspNetProjekt.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AspNetProjekt.Models.Item", null)
                        .WithMany()
                        .HasForeignKey("itemsItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CustomerItem", b =>
                {
                    b.HasOne("AspNetProjekt.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("ItemLikesCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AspNetProjekt.Models.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemLikesItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CustomerItem1", b =>
                {
                    b.HasOne("AspNetProjekt.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomerWishListCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AspNetProjekt.Models.Item", null)
                        .WithMany()
                        .HasForeignKey("CustomerWishListItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("AspNetProjekt.Models.MyUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("AspNetProjekt.Models.MyUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AspNetProjekt.Models.MyUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("AspNetProjekt.Models.MyUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AspNetProjekt.Models.Customer", b =>
                {
                    b.Navigation("CustomerShoppingCart");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("AspNetProjekt.Models.CustomerShoppingCart", b =>
                {
                    b.Navigation("CustomerShoppingCart_Items");
                });

            modelBuilder.Entity("AspNetProjekt.Models.Item", b =>
                {
                    b.Navigation("CustomerShoppingCart_Item");

                    b.Navigation("Transaction_Items");
                });

            modelBuilder.Entity("AspNetProjekt.Models.MyUser", b =>
                {
                    b.Navigation("customer");
                });

            modelBuilder.Entity("AspNetProjekt.Models.Transaction", b =>
                {
                    b.Navigation("transaction_Items");
                });
#pragma warning restore 612, 618
        }
    }
}
