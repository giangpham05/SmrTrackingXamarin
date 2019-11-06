using System;
using System.Collections.Generic;

namespace SMR.Tracking.Domain
{
    public class WalkByInspection: Audit
    {
        public Guid Id { get; set; }
        public int No { get; set; }
        public DateTime InspectionDate { get; set; }
        public ICollection<WalkByInspector> WalkByInspectors { get; set; }
        public int Location { get; set; }
        public string Description { get; set; }
        public string Gauge { get; set; }
        public string Super { get; set; }
        public string PoorSleepers { get; set; }
        public Guid? AssetConditionId { get; set; }
        public AssetCondition AssetCondition { get; set; }
        public Guid? LocationPrefixId { get; set; }
        public LocationPrefix LocationPrefix { get; set; }
        public ICollection<Defect> Defects { get; set; }
    }
}
