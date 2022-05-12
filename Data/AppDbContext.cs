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
        }

        public DbSet<UserModel> Users { get; set; }
        /*
        public DbSet<CardModel> Cards { get; set; }
        public DbSet<MenuModel> Menus { get; set; }
        public DbSet<TypeModel> Types { get; set; }
        public DbSet<PhotoModel> Photos { get; set; }
        public DbSet<ItemModel> Items { get; set; }
        */
    }
}
