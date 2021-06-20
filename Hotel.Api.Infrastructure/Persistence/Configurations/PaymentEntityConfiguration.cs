using Hotel.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Api.Infrastructure.Persistence.Configurations
{
    public class PaymentEntityConfiguration : BaseEntityConfiguration<Payment>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Payment> builder)
        {
            builder.HasOne(x => x.User).WithMany(x => x.Payments).HasForeignKey(x => x.UserId);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Price).IsRequired();
        }
    }
}
