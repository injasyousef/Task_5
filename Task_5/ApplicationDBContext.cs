using Microsoft.EntityFrameworkCore;
using Task_5.Configuration;
using Task_5.Tables;

namespace Task_5
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> option) : base(option)
        {

        }

        public DbSet<City> City { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Emp_Trans_Sal> EmpTransSalary { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CityConfig());
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new Emp_trans_salConfig());

        }
    }
}
