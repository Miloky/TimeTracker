using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TimeTracker.Application.Interfaces;
using TimeTracker.Persistence;

namespace TimeTracker.WebHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = CreateWebHostBuilder(args).Build();

            using (IServiceScope scope = host.Services.CreateScope())
            {
                try
                {
                    ITimeTrackerDbContext abstractContext = scope.ServiceProvider.GetService<ITimeTrackerDbContext>();
                    TimeTrackerDbContext context = (TimeTrackerDbContext)abstractContext;
                    context.Database.Migrate();


                    throw new Exception("Test");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            Microsoft.AspNetCore.WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var environment = hostingContext.HostingEnvironment;
                    config
                        .AddJsonFile("appsettings.json", false)
                        .AddJsonFile("appsettings.Local.json", true, true)
                        .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true, true);
                    config.AddEnvironmentVariables();
                })
                .UseStartup<Startup>();
    }
}
