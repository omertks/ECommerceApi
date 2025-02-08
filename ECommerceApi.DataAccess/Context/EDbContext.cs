using ECommerceApi.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Diagnostics;
using MongoDB.EntityFrameworkCore.Extensions;

namespace ECommerceApi.Contexts
{
    public class EDbContext : DbContext
    {

        public EDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Address> addresses { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Picture> pictures { get; set; }
        public DbSet<Store> stores { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<OrdersItems> orders_items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                //.UseLazyLoadingProxies() // İlişkili nesnelerin gerektiğinde yüklenmesi için
                .UseMongoDB("mongodb://localhost:27017", "e_commerce_api_db");
            

            // Burası ne yav
            Database.AutoTransactionBehavior = AutoTransactionBehavior.Never;

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            #region Collection And Id Config

            // Id alanlarının konfigurasyonu

            modelBuilder.Entity<Address>()
                .ToCollection("addresses")
                .Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Category>()
                .ToCollection("categories")
                .Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Comment>()
                .ToCollection("comments")
                .Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Order>()
                .ToCollection("orders")
                .Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Picture>()
                .ToCollection("pictures")
                .Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Store>()
                .ToCollection("stores")
                .Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Product>()
                .ToCollection("products")
                .Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Store>()
                .ToCollection("stores")
                .Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<User>()
                .ToCollection("users")
                .Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            #endregion


            #region Relationships

            // Products:
            // Product - Comments   OneToMany
            modelBuilder.Entity<Product>()
                .HasMany(x => x.Comments)
                .WithOne(c => c.Product)
                .HasForeignKey(c => c.ProductId);

            // Product - Pictures   OneToMany
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Pictures)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId);

            // Product - Category ManyToMany
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Categories)
                .WithMany(c => c.Products)
                .UsingEntity(j => j.ToCollection("product_categories"));


            // Store:
            // Store - Products    OneToMany
            modelBuilder.Entity<Store>()
                .HasMany(s => s.Products)
                .WithOne(p => p.Store)
                .HasForeignKey(p => p.StoreId);

            // Store - User        ManyToOne
            modelBuilder.Entity<Store>()
                .HasMany(s => s.Followers)
                .WithMany(u => u.FollowingStores)
                .UsingEntity(j => j.ToCollection("store_follower"));

            // User:
            // User - Order
            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.Owner)
                .HasForeignKey(o => o.OwnerId);

            // User - Address
            modelBuilder.Entity<User>()
                .HasMany(u => u.Addresses)
                .WithOne(a => a.Owner)
                .HasForeignKey(a => a.OwnerId);

            // Order:
            // Order - Store
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Store)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.StoreId);

            // Order - User
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Owner)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.OwnerId);

            // Order - OrdersItems
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrdersItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);

            #endregion
        }

    }
}
