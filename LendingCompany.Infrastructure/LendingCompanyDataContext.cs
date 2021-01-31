using Microsoft.EntityFrameworkCore;
using LendingCompany.BL.Model;

namespace LendingCompany.Infrastructure
{
    public class LendingCompanyDataContext : DbContext
    {
        public LendingCompanyDataContext(DbContextOptions<LendingCompanyDataContext> options) : base(options)
        {

        }

        public virtual DbSet<Loan> Loan { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>(entity =>
                entity.HasKey(l => l.Id));

            modelBuilder.Entity<Payment>(entity =>
                entity.HasKey(p => p.Id));

            modelBuilder.Entity<Person>(entity =>
                entity.HasKey(p => p.Id));

            modelBuilder.Entity<Loan>(entity =>
                entity.HasMany(l => l.Payments));

            modelBuilder.Entity<Loan>(entity =>
                entity.HasOne(l => l.Person));
        }
    }
}
