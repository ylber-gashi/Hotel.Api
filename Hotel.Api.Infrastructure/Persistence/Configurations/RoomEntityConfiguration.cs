using Hotel.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Api.Infrastructure.Persistence.Configurations
{
    public class RoomEntityConfiguration : BaseEntityConfiguration<Room>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Room> builder)
        {
            builder.Property(x => x.RoomNumber).IsRequired();
            builder.Property(x => x.FloorNumber).IsRequired();
            builder.Property(x => x.Capacity).IsRequired();
            builder.Property(x => x.RoomType).IsRequired();
            builder.Property(x => x.Price).IsRequired();
        }
    }
}
