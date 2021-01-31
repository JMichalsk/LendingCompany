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

        public virtual DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
