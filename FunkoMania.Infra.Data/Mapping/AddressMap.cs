using FunkoMania.Domain.Entities;
using FunkoMania.Domain.Shared.Parameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunkoMania.Infra.Data.Mapping
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable(TableNames.TbAddress);
            builder.Property(a => a.Street).HasMaxLength(200).IsRequired();
            builder.Property(a => a.Number).HasMaxLength(5);
            builder.Property(a => a.Complement).HasMaxLength(200);
            builder.Property(a => a.Neighborhood).HasMaxLength(100).IsRequired();
            builder.Property(a => a.City).HasMaxLength(50).IsRequired();
            builder.Property(a => a.State).HasMaxLength(2).IsRequired();
            builder.Ignore(a => a.Deleted);

        }
    }
}
