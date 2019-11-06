using System;
using System.Collections.Generic;

namespace SMR.Tracking.Domain
{
    public class LocationPrefix: Audit
    {
        public Guid Id { get; set; }
        public string Label { get; set; }
        public ICollection<Defect> Defects { get; set; }
        public ICollection<WalkByInspection> WalkByInspections { get; set; }
        public ICollection<LocationIncrement> LocationIncrements { get; set; }
    }
}
