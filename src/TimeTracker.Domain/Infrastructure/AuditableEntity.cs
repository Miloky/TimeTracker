using System;

namespace TimeTracker.Domain.Infrastructure
{
    public class AuditableEntity<T>
    {
        public T CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public T ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}