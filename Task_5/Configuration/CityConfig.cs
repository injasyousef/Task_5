using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Task_5.Tables;

namespace Task_5.Configuration
{
    public class CityConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(c => c.cityId);

            builder.Property(v => v.cityName).HasMaxLength(200).IsRequired();

        }
    }
}

