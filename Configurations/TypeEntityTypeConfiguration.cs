using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System.Linq;
using System.Threading.Tasks;
using LebaneseHomemadeLibrary;
using Microsoft.EntityFrameworkCore;

namespace LebaneseHomemade.Configurations
{
    public class TypeEntityTypeConfiguration : IEntityTypeConfiguration<TypeModel>
    {
        public void Configure(EntityTypeBuilder<TypeModel> builder)
        {
            //required columns
            builder.Property(prop => prop.Name).IsRequired();
            //columns types
            builder.Property(prop => prop.Name).HasColumnType("varchar(50)");
        }
    }
}
