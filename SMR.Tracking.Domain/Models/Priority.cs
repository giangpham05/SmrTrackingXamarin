using System;
using System.Collections.Generic;

namespace SMR.Tracking.Domain
{
    public class Priority: Audit
    {
        public Guid Id { get; set; }
        public string Label { get; set; }
        public int DueDays { get; set; }
        public ICollection<Defect> Defects { get; set; }
        public ICollection<DefectType> DefectTypes { get; set; }
    }
}
