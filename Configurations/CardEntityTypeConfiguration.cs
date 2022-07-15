using LebaneseHomemadeLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LebaneseHomemade.Configurations
{
    public class CardEntityTypeConfiguration : IEntityTypeConfiguration<CardModel>
    {
        public void Configure(EntityTypeBuilder<CardModel> builder)
        {
            //required columns
            builder.Property(prop => prop.Title).IsRequired();
            builder.Property(prop => prop.TypeId).IsRequired();
            builder.Property(prop => prop.UserId).IsRequired();
            //columns types
            builder.Property(prop => prop.Title).HasColumnType("nvarchar(30)");
            builder.Property(prop => prop.InstagramLink).HasColumnType("nvarchar(30)");
            builder.Property(prop => prop.FaceBookLink).HasColumnType("nvarchar(50)");
            builder.Property(prop => prop.WhatsAppLink).HasColumnType("int");
            builder.Property(prop => prop.DateCreated).HasColumnType("smalldatetime");
            //date default value
            builder.Property(prop => prop.DateCreated).HasDefaultValueSql("getdate()");
        }
    }
}
