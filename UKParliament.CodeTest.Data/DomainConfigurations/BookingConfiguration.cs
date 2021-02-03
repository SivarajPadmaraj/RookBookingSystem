using UKParliament.CodeTest.Data.Domain;
using UKParliament.CodeTest.Data.DomainConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UKParliament.CodeTest.Data.DomainConfigurations
{
    internal sealed class BookingConfiguration : BaseEntityConfiguration<Booking>
    {
        public override void Configure(EntityTypeBuilder<Booking> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.StartDate);
            builder.Property(e => e.EndDate);

            builder.HasOne(e => e.Person)
                   .WithMany(e => e.Bookings)
                   .HasForeignKey(e => e.PersonId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Room)
                   .WithMany(e => e.Bookings)
                   .HasForeignKey(e => e.RoomId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
