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
            builder.Property(prop => prop.TypeId).IsRequired();
            builder.Property(prop => prop.UserId).IsRequired();
            //columns types
            builder.Property(prop => prop.InstagramLink).HasColumnType("varchar(2083)");
            builder.Property(prop => prop.FaceBookLink).HasColumnType("varchar(2083)");
            builder.Property(prop => prop.WhatsAppLink).HasColumnType("varchar(2083)");
            builder.Property(prop => prop.DateCreated).HasColumnType("smalldatetime");

            builder.Property(prop => prop.DateCreated).HasDefaultValueSql("getdate()");
        }
    }
}
