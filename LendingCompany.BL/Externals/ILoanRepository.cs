﻿using System;
using System.Threading.Tasks;
using LendingCompany.BL.Model;

namespace LendingCompany.BL.Externals
{
    public interface ILoanRepository
    {
        Task<Guid> CreateLoanAsync(Loan loan);
    }
}
