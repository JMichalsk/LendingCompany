using System;
using System.Linq;
using System.Threading.Tasks;
using LendingCompany.BL.Externals;
using LendingCompany.BL.Model;
using LendingCompany.BL.Services.Interfaces;

namespace LendingCompany.BL.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IUnitOfWork _uow;

        public PaymentService(IPaymentRepository paymentRepository, IUnitOfWork uow)
        {
            _paymentRepository = paymentRepository;
            _uow = uow;
        }

        public async Task<Payment> CreatePayment(Guid loanId, double baseAmount, DateTime loanCreationDate)
        {
            var payment = new Payment(baseAmount, loanCreationDate.AddMonths(1), loanId);
            await _paymentRepository.CreatePaymentAsync(payment);

            return payment;
        }

        public async Task<double> FoundPayment(Guid loanId, double amount)
        {
            var payments = _paymentRepository.GetPaymentsWhere(x 
                => (x.Id == loanId && !x.IsPaid));

            var lastPayment = payments
                .OrderBy(x => x.FinalPaymentDate)
                .FirstOrDefault();

            if (lastPayment != null)
            {
                var rest = lastPayment.Pay(amount);

                if (rest != 0)
                {
                    rest = await FoundPayment(loanId, rest);
                    return rest;
                }

                await _uow.CompleteAsync();
                return 0;
            }

            await _uow.CompleteAsync();
            return amount;
        }
    }
}
