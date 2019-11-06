using System;
using System.Collections.Generic;

namespace SMR.Tracking.Domain
{
    public class Status: Audit
    {
        public Guid Id { get; set; }
        public string Label { get; set; }
        public ICollection<Defect> Defects { get; set; }
    }
}
