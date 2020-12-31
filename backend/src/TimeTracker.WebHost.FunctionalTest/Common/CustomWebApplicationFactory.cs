using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TimeTracker.Application.Interfaces;
using TimeTracker.Persistence;

namespace TimeTracker.WebHost.FunctionalTest.Common
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Create a new service provider.
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                services.AddDbContext<ITimeTrackerDbContext, TimeTrackerDbContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                //Build the service provider
                var sp = services.BuildServiceProvider();

                //Create a scope to obtain a reference  to the database
                // context (TimeTrackerDbContext)
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var context = scopedServices.GetRequiredService<ITimeTrackerDbContext>();
                    var logger = scopedServices
                        .GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                    var concreteContext = (TimeTrackerDbContext)context;
                    concreteContext.Database.EnsureCreated();

                    //try
                    //{
                        Utilities.InitializeDbForTest(concreteContext);
                        // Seed database
                    //}
                    //catch (Exception ex)
                    //{
                        // log error
                    //}
                }

            });
        }
    }
}