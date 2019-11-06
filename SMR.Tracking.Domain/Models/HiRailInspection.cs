using System;
using System.Collections.Generic;

namespace SMR.Tracking.Domain
{
    public class HiRailInspection: Audit
    {
        public Guid Id { get; set; }
        public int No { get; set; }
        public DateTime InspectionDate { get; set; }
        public ICollection<HiRailInspector> HiRailInspectors { get; set; }
        public ICollection<HiRailMatrix> HiRailMatrices { get; set; }
        public Guid? AssetConditionId { get; set; }
        public AssetCondition AssetCondition { get; set; }
    }
}
