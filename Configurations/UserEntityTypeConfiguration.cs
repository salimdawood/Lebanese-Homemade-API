using LebaneseHomemadeLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LebaneseHomemade.Configurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            //required columns
            builder.Property(prop => prop.Name).IsRequired();
            builder.Property(prop => prop.Email).IsRequired();
            builder.Property(prop => prop.Password).IsRequired();
            //columns types
            builder.Property(prop => prop.Name).HasColumnType("varchar(50)");
            builder.Property(prop => prop.Email).HasColumnType("varchar(50)");
            builder.Property(prop => prop.Password).HasColumnType("varchar(100)");
            builder.Property(prop => prop.Location).HasColumnType("varchar(50)");
        }
    }
}
