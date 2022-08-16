using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LebaneseHomemadeLibrary;
using Microsoft.EntityFrameworkCore;

namespace LebaneseHomemade.Configurations
{
    public class ItemEntityTypeConfiguration : IEntityTypeConfiguration<ItemModel>
    {
        public void Configure(EntityTypeBuilder<ItemModel> builder)
        {
            //required columns
            builder.Property(prop => prop.Name).IsRequired();
            builder.Property(prop => prop.MenuId).IsRequired();
            //columns types
            builder.Property(prop => prop.Name).HasColumnType("nvarchar(50)");
            builder.Property(prop => prop.Price).HasColumnType("varchar(20)");
            //indexes
            builder.HasIndex(prop => prop.MenuId).IsClustered(false).IncludeProperties(prop => new { prop.Name,prop.Price });
        }
    }
}
