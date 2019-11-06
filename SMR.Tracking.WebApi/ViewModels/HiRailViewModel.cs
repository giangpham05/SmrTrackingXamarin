using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMR.Tracking.WebApi.ViewModels
{
    public class HiRailViewModel
    {
        [Required]
        public ICollection<HiRailMatrixViewModel> HiRailMatrices { get; set; }

        [Required]
        public Guid Id { get; set; }
        
        [Required]
        public DateTime InspectionDate { get; set; }
        
        [Required]
        public List<Guid> Inspectors { get; set; }
        
        [Required]
        public Guid AssetCondition { get; set; }
        
        public int? No { get; set; }
    }
}
