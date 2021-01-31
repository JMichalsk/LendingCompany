using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LendingCompany.BL.Model;

namespace LendingCompany.BL.Externals
{
    public interface IPaymentRepository
    {
        Task<Guid> CreatePaymentAsync(Payment payment);
        IList<Payment> GetPaymentsWhere(Expression<Func<Payment, bool>> expression);
    }
}
