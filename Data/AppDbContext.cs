using LebaneseHomemade.Configurations;
using LebaneseHomemadeLibrary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LebaneseHomemade.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<UserModel>());
            new PhotoEntityTypeConfiguration().Configure(modelBuilder.Entity<PhotoModel>());
            new CardEntityTypeConfiguration().Configure(modelBuilder.Entity<CardModel>());
            new ItemEntityTypeConfiguration().Configure(modelBuilder.Entity<ItemModel>());
            new TypeEntityTypeConfiguration().Configure(modelBuilder.Entity<TypeModel>());
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<CardModel> Cards { get; set; }
        public DbSet<MenuModel> Menus { get; set; }
        public DbSet<TypeModel> Types { get; set; }
        public DbSet<PhotoModel> Photos { get; set; }
        public DbSet<ItemModel> Items { get; set; }
    }
}
