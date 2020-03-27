using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TimeTracker.Persistence.Infrastructure
{
    public abstract class DesignTimeDbContextFactoryBase<TContext> : IDesignTimeDbContextFactory<TContext> where TContext : DbContext
    {
        private const string ConnectionStringName = "TimeTracker";
        private const string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";

        public TContext CreateDbContext(string[] args)
        {
            string basePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName,
                "TimeTracker.WebHost");
            string environmentVariable = Environment.GetEnvironmentVariable(AspNetCoreEnvironment);
            return Create(basePath, environmentVariable);
        }

        protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);

        private TContext Create(string basePath, string environment)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile("appsettings.Local.json", true)
                .AddJsonFile($"appsettings.{environment}.json", true)
                .AddEnvironmentVariables(environment)
                .Build();

            string connectionString = configuration.GetConnectionString(ConnectionStringName);
            return Create(connectionString);
        }

        private TContext Create(string connectionString)
        {
            if (String.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException($"Connection string '{ConnectionStringName}' is null or empty.", nameof(connectionString));
            }

            Console.WriteLine($"DesignTimeDbConnectionFactoryBase.Create(string): Connection string: '{connectionString}'.");

            DbContextOptionsBuilder<TContext> optionsBuilder = new DbContextOptionsBuilder<TContext>();
            optionsBuilder.UseMySQL(connectionString);

            return CreateNewInstance(optionsBuilder.Options);
        }
    }
}