﻿using System;
using System.Threading.Tasks;
using LendingCompany.BL.Externals;
using LendingCompany.BL.Model;

namespace LendingCompany.Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LendingCompanyDataContext _dbContext;
        public LoanRepository(LendingCompanyDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> CreateLoanAsync(Loan loan)
        {
            var result = await _dbContext.Loan.AddAsync(loan);
            return result.Entity.Id;
        }
    }
}
