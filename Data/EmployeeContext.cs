using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(employee =>
            {
                employee.ToTable("Employees");
                employee.HasKey(e => e.EmployeeId);
                employee.Property(e => e.EmployeeId).ValueGeneratedOnAdd();
                employee.Property(e => e.Name).HasColumnType("varchar(50)").HasMaxLength(50);
                employee.Property(e => e.LastName).HasColumnType("varchar(50)").HasMaxLength(50);
                employee.Property(e => e.LastName).HasColumnType("varchar(30)").HasMaxLength(30);

                employee.OwnsOne(e => e.Salary)
                    .Property(e => e.Amount)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("MoneyAmount")
                    .IsRequired();

                employee.OwnsOne(e => e.Salary)
                    .Property(e => e.Currency)
                    .HasColumnType("varchar(3)")
                    .HasMaxLength(3)
                    .HasColumnName("MoneyCurrency")
                    .IsRequired();

                employee.OwnsOne(e => e.AnnualSalary)
                    .Property(e => e.Amount)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("MoneyAmount")
                    .IsRequired();

                employee.OwnsOne(e => e.AnnualSalary)
                    .Property(e => e.Currency)
                    .HasColumnType("varchar(3)")
                    .HasMaxLength(3)
                    .HasColumnName("MoneyCurrency")
                    .IsRequired();
            });
        }

    }
}
