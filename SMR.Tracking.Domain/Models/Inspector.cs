using System;
using System.Collections.Generic;

namespace SMR.Tracking.Domain
{
    public class Inspector: Audit
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<DefectInspector> DefectInspectors { get; set; }
        public ICollection<HiRailInspector> HiRailInspectors { get; set; }
        public ICollection<WalkByInspector> WalkByInspectors { get; set; }
    }
}
