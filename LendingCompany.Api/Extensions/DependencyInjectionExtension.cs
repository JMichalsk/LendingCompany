
using LendingCompany.BL.Externals;
using LendingCompany.BL.Services;
using LendingCompany.BL.Services.Interfaces;
using LendingCompany.Infrastructure.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ILoanService, LoanService>();
            services.AddScoped<IPaymentService, PaymentService>();
        }
    }
}
