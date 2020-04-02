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
        // Max Length 10 letters 
        public string Prefix { get; set; }
        public string Title { get; set; }
        // public string Description{get;set;}
        public ICollection<Issue> Issues { get; set; }
    }
}
