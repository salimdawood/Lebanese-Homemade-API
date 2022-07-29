using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System.Linq;
using System.Threading.Tasks;
using LebaneseHomemadeLibrary;
using Microsoft.EntityFrameworkCore;

namespace LebaneseHomemade.Configurations
{
    public class PhotoEntityTypeConfiguration : IEntityTypeConfiguration<PhotoModel>
    {
        public void Configure(EntityTypeBuilder<PhotoModel> builder)
        {
            //required columns
            builder.Property(prop => prop.Name).IsRequired();
            builder.Property(prop => prop.CardId).IsRequired();
            //columns types
            builder.Property(prop => prop.Name).HasColumnType("nvarchar(100)");
        }
    }
}
