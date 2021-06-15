using Hotel.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Api.Infrastructure.Persistence.Configurations
{
    public class ReservationEntityConfiguration : BaseEntityConfiguration<Reservation>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasOne(x => x.User).WithMany(x => x.Reservations).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Room).WithMany(x => x.Reservations).HasForeignKey(x => x.RoomId);
            builder.Property(x => x.CheckInDate).IsRequired();
            builder.Property(x => x.CheckOutDate).IsRequired();
            builder.HasOne(x => x.Payment).WithMany(x => x.Reservations).HasForeignKey(x => x.PaymentId);
        }
    }
}
