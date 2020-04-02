
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
        //public string Description { get; set; }
        // Key: MBX-123 or MBX-2293 etc.
        public string Identifier { get; set; }
        public string Title { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public ICollection<WorkLog> WorkLogs { get; set; }
    }
}
