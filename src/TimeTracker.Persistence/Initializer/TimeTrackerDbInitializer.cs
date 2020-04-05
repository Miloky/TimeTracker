using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Persistence.Initializer
{
    public class TimeTrackerDbInitializer
    {
        private readonly IDictionary<int, Project> _projects = new Dictionary<int, Project>();

        public static void Seed(TimeTrackerDbContext context)
        {
            if (context.Projects.FirstOrDefault() != null) return;
            var initilizer = new TimeTrackerDbInitializer();
            initilizer.SeedEverything(context);
        }

        private void SeedEverything(TimeTrackerDbContext context)
        {
            SeedProjects(context);
            SeedIssues(context);
        }

        private void SeedIssues(TimeTrackerDbContext context)
        {
            var issues = new Issue[]
            {
                new Issue
                {
                    Title = "Harry Potter and philosopher's stone"
                },
                new Issue
                {
                    Title = "Harry Potter and philosopher's stone",
                }
            };

            context.Issues.AddRange(issues);

            foreach (Issue issue in issues)
            {
                issue.Project = _projects[1];
                issue.Identifier = $"{issue.Project.Prefix}-{issue.Id}";
            }

            context.SaveChanges();
        }

        private void SeedProjects(TimeTrackerDbContext context)
        {
            _projects.Add(1, new Project
            {
                Prefix = "ENG",
                Title = "English  study"
            });
            _projects.Add(2, new Project
            {
                Prefix = "JS",
                Title = "Javascript learning path"
            });
            _projects.Add(3, new Project
            {
                Prefix = "EB",
                Title = "English books"
            });

            foreach (Project project in _projects.Values)
            {
                context.Projects.Add(project);
            }
            context.SaveChanges();
        }

        private static string ReadSqlFile(string name)
        {
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return File.ReadAllText(Path.Combine(assemblyPath, "Initializer", name));
        }
    }
}
