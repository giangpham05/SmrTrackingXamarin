using System;
using System.Collections.Generic;

namespace SMR.Tracking.Domain
{
    public class AssetCondition: Audit
    {
        public Guid Id { get; set; }
        public string Label { get; set; }
        public ICollection<HiRailInspection> HiRailInspections { get; set; }
        public ICollection<WalkByInspection> WalkByInspections { get; set; }
        public ICollection<HiRailMatrix> HiRailMatrices { get; set; }
    }
}
