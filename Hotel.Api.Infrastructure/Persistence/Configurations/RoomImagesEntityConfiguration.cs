using Hotel.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Api.Infrastructure.Persistence.Configurations
{
    public class RoomImagesEntityConfiguration : BaseEntityConfiguration<RoomImage>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<RoomImage> builder)
        {
            builder.Property(x => x.URL).IsRequired();
            builder.HasOne(x => x.Room).WithMany(x => x.Images).HasForeignKey(x => x.RoomId);
        }
    }

}
