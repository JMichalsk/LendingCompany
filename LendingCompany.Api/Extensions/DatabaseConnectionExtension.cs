using LendingCompany.Api.ConfigurationMappings;
using LendingCompany.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LendingCompany.Api.Extensions
{
    public static class DatabaseConnectionExtension
    {
        public static void AddInMemoryDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LendingCompanyDataContext>(options => 
                options.UseInMemoryDatabase(configuration.GetSection("DatabaseConnections:MsSqlConnection")
                    .Get<MsSqlConnection>()
                    .DatabaseName));
        }
    }
}
