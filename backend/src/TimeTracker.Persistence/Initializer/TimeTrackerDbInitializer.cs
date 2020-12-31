using System;
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
        private readonly IDictionary<int, Issue> _issues = new Dictionary<int, Issue>();

        public static void Seed(TimeTrackerDbContext context)
        {
            if (context.Projects.FirstOrDefault() != null) return;
            var initializer = new TimeTrackerDbInitializer();
            initializer.SeedEverything(context);
        }

        private void SeedEverything(TimeTrackerDbContext context)
        {
            SeedProjects(context);
            SeedIssues(context);
            SeedWorkLogs(context);
        }

        private void SeedWorkLogs(TimeTrackerDbContext context)
        {
            var start = DateTime.Now;
            var end = start.AddHours(5);
            var worklogs = new WorkLog[]
            {
                new WorkLog
                {
                    Issue = _issues[2],
                    EndDate = end,
                    StartDate = start,
                    Duration = Convert.ToInt32((end-start).TotalMinutes)
                },
                new WorkLog
                {
                    Issue = _issues[2],
                    StartDate = DateTime.Parse("04/05/2020 20:00:00")
                }
            };
            context.WorkLogs.AddRange(worklogs);
            context.SaveChanges();
        }

        private void SeedIssues(TimeTrackerDbContext context)
        {
            _issues.Add(1, new Issue
            {
                Title = "Harry Potter and philosopher's stone",
                Project = _projects[1]
            });
            _issues.Add(2, new Issue
            {
                Title = "JavaScript Promises",
                Project = _projects[2]
            });


            foreach (Issue issue in _issues.Values)
            {
                context.Issues.Add(issue);
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
