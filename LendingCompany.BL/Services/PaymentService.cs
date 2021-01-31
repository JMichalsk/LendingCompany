using System;
using System.Threading.Tasks;
using LendingCompany.BL.Externals;
using LendingCompany.BL.Model;
using LendingCompany.BL.Services.Interfaces;

namespace LendingCompany.BL.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<Payment> CreatePayment(double baseAmount, DateTime loanCreationDate, Guid loanId)
        {
            var payment = new Payment(baseAmount, loanCreationDate.AddMonths(1), loanId);
            await _paymentRepository.CreatePaymentAsync(payment);

            return payment;
        }
    }
}
