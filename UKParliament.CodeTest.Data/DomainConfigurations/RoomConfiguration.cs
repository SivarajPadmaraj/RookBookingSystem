using UKParliament.CodeTest.Data.Domain;
using UKParliament.CodeTest.Data.DomainConfigurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UKParliament.CodeTest.Data.DomainConfigurations
{
    internal sealed class RoomConfiguration : BaseEntityConfiguration<Room>
    {
        public override void Configure(EntityTypeBuilder<Room> builder)
        {
            base.Configure(builder);

            builder.HasIndex(e => e.Name).IsUnique();
            builder.Property(e => e.Name).IsRequired();
        }
    }
}
