
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UKParliament.CodeTest.Data
{
    internal sealed class PersonConfiguration : BaseEntityConfiguration<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Email);
            builder.Property(e => e.DateOfBirth);
        }
    }
}