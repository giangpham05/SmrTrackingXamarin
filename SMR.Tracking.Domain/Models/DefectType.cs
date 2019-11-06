using System;
using System.Collections.Generic;

namespace SMR.Tracking.Domain
{
    public class DefectType: Audit
    {
        public Guid Id { get; set; }
        public Guid? St2Id { get; set; }
        public ST2 St2 { get; set; }
        public string Label { get; set; }
        public Guid? PriorityId { get; set; }
        public Priority Priority { get; set; }
        public string DefectAction { get; set; }
        public ICollection<Defect> Defects { get; set; }
    }
}
