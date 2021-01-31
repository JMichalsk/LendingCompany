using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>(entity =>
                entity.HasKey(l => l.Id));

            modelBuilder.Entity<Payment>(entity =>
                entity.HasKey(p => p.Id));

            modelBuilder.Entity<Loan>(entity =>
                entity.HasMany(l => l.Payments));
        }
    }
}
