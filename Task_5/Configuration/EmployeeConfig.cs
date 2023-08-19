using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task_5.Tables;

namespace Task_5.Configuration
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(c => c.empId);

            builder.Property(v => v.empName).HasMaxLength(200).IsRequired();

            builder.HasOne(e => e.city)
                  .WithMany(c => c.Employees)  
                  .HasForeignKey(e => e.cityId);

        }
    }
}

