using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using LendingCompany.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace LendingCompany.IntegrationTests
{
    public class LoanControllerTests
    {
        [Test]
        public async Task ShouldRejectWhenPersonTooYoung()
        {
            using var host = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(builder =>
                    builder
                        .UseStartup<Startup>()
                        .UseTestServer()
                )
                .Build();
            await host.StartAsync();

            using var client = host.GetTestClient();

            using var httpResponseMessage = await client
                .PostAsync("api/Person/Create", new StringContent(TooYoungPerson(), Encoding.UTF8, "application/json"));

            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        private static string TooYoungPerson()
        {
            return new JObject(
                new JProperty("firstName", "Anna"),
                new JProperty("lastName", "Manna"),
                new JProperty("dateOfBirth", DateTime.UtcNow.AddYears(-18).AddDays(1)),
                new JProperty("pesel", "12345678901")).ToString();
        }
    }
}
