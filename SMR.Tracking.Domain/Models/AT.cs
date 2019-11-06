using System;
using System.Collections.Generic;

namespace SMR.Tracking.Domain
{
    public class AT: Audit
    {
        public Guid Id { get; set; }
        public string Label { get; set; }
        public ICollection<Defect> Defects { get; set; }
        public ICollection<ST1> St1s { get; set; }
    }
}
