using System;

namespace SMR.Tracking.Domain
{
    public class HiRailMatrix: Audit
    {
        public Guid Id { get; set; }
        public Guid? HiRailInspectionId { get; set; }
        public HiRailInspection HiRailInspection { get; set; }

        public Guid? HiRailLocationId { get; set; }
        public HiRailLocation HiRailLocation { get; set; }

        public Guid? HiRailAssetTypeId { get; set; }
        public HiRailAssetType HiRailAssetType { get; set; }

        public Guid? AssetConditionId { get; set; }
        public AssetCondition AssetCondition { get; set; }
    }
}
