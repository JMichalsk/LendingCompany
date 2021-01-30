using System;
using static LendingCompany.Api.Assemblies;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LendingCompany.Api.Extensions
{
    public static class MediatRExtension
    {
        public static void AddMediator(this IServiceCollection services)
        {
            var postAssembly = AppDomain.CurrentDomain.Load(BusinessLogicAssembly);
            services.AddMediatR(postAssembly);
        }
    }
}
