
using System.Collections.Generic;

namespace TimeTracker.Domain.Entities
{
    public class Issue
    {
        public Issue()
        {
            WorkLogs = new HashSet<WorkLog>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public ICollection<WorkLog> WorkLogs { get; set; }
    }
}
