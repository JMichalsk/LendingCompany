using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using static LendingCompany.Api.Assemblies;

namespace LendingCompany.Api.Extensions
{
    public static class AutoMapperExtension
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.Load(BusinessLogicAssembly));
        }
    }
}
