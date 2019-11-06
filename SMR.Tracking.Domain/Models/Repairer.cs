using System;
using System.Collections.Generic;

namespace SMR.Tracking.Domain
{
    public partial class Repairer: Audit
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<DefectRepairLine> DefectRepairLines { get; set; }
        public ICollection<Defect> Defects { get; set; }
    }
}
