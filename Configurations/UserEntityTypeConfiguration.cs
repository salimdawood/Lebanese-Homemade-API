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
            builder.Property(prop => prop.Name).HasColumnType("nvarchar(30)");
            builder.Property(prop => prop.Email).HasColumnType("nvarchar(50)");
            builder.Property(prop => prop.Password).HasColumnType("nvarchar(20)");
            builder.Property(prop => prop.Location).HasColumnType("nvarchar(50)");
        }
    }
}
