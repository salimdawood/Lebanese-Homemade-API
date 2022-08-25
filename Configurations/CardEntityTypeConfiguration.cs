using LebaneseHomemadeLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            builder.Property(prop => prop.WhatsAppLink).HasColumnType("nvarchar(8)");
            builder.Property(prop => prop.DateCreated).HasColumnType("smalldatetime");
            //date default value
            builder.Property(prop => prop.DateCreated).HasDefaultValueSql("getdate()");
            //indexes
            builder.HasIndex(prop => prop.TypeId).IsClustered(false).IncludeProperties(prop => new
            { prop.Title,prop.DateCreated,prop.FaceBookLink,prop.InstagramLink,prop.WhatsAppLink,prop.UserId });
            builder.HasIndex(prop => prop.UserId).IsClustered(false).IncludeProperties(prop => new
            { prop.Title, prop.DateCreated, prop.FaceBookLink, prop.InstagramLink, prop.WhatsAppLink, prop.TypeId });
            builder.HasIndex(prop => prop.DateCreated).IsClustered(false).IncludeProperties(prop => new
            { prop.Title, prop.FaceBookLink, prop.InstagramLink, prop.WhatsAppLink, prop.TypeId,prop.UserId });
        }
    }
}
