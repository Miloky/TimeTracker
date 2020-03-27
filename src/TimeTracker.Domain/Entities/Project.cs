using System.Collections.Generic;

namespace TimeTracker.Domain.Entities
{
    public class Project
    {
        public Project()
        {
            Issues = new HashSet<Issue>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Issue> Issues { get; set; }
    }
}
