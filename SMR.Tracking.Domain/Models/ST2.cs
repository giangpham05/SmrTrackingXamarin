using System;
using System.Collections.Generic;

namespace SMR.Tracking.Domain
{
    public partial class ST2: Audit
    {
        public Guid Id { get; set; }
        public string Label { get; set; }
        public Guid? St1Id { get; set; }
        public ST1 St1 { get; set; }
        public ICollection<Defect> Defects { get; set; }
        public ICollection<DefectType> DefectTypes { get; set; }
    }
}
