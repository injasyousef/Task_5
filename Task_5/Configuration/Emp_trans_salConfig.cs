using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Task_5.Tables;

namespace Task_5.Configuration
{
    public class Emp_trans_salConfig : IEntityTypeConfiguration<Emp_Trans_Sal>
    {
        public void Configure(EntityTypeBuilder<Emp_Trans_Sal> builder)
        {
            builder.HasKey(c => c.emp_trans_salId);


            builder.Property(t => t.salaryDate).IsRequired();

            builder.HasOne(t => t.employee)
                   .WithMany(e => e.Transactions)
                   .HasForeignKey(t => t.empId);

        }
    }
}

