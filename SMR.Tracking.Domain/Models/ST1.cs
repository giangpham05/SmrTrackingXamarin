using System;
using System.Collections.Generic;

namespace SMR.Tracking.Domain
{
    public class ST1: Audit
    {
        public Guid Id { get; set; }
        public string Label { get; set; }        
        public ICollection<Defect> Defects { get; set; }
        public Guid? AtId { get; set; }
        public AT At { get; set; }
        public ICollection<ST2> St2s { get; set; }
    }
}
