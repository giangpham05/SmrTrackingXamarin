using System;
using System.ComponentModel.DataAnnotations;

namespace SMR.Tracking.WebApi.ViewModels
{
    public class HiRailMatrixViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid HiRailInspectionId { get; set; }

        [Required]
        public Guid HiRailLocationId { get; set; }

        [Required]
        public Guid HiRailAssetTypeId { get; set; }

        [Required]
        public Guid AssetConditionId { get; set; }
    }
}
