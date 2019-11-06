using System;
using System.Collections.Generic;

namespace SMR.Tracking.Domain
{
    public class HiRailAssetType: Audit
    {
        public Guid Id { get; set; }
        public string Label { get; set; }
        public ICollection<HiRailMatrix> HiRailMatrices { get; set; }
    }
}
