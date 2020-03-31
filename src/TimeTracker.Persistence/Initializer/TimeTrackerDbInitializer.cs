using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TimeTracker.Application.Interfaces;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Persistence.Initializer
{
    public class TimeTrackerDbInitializer
    {
        public static void Seed(TimeTrackerDbContext context)
        {
            SeedProjects(context);
        }

        private static void SeedProjects(TimeTrackerDbContext context)
        {    
            if (context.Projects.FirstOrDefault()!= null) return;
            string sql = ReadSqlFile("projects.sql");
            context.Database.ExecuteSqlCommand(sql);
            context.SaveChanges();
        }

        private static string ReadSqlFile(string name)
        {
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
             return File.ReadAllText(Path.Combine(assemblyPath, "Initializer", name));
        }
    }
}
