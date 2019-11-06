using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SMR.Tracking.WebApi.ViewModels
{
    public class DefectViewModel
    {
        [Required]
        public Guid Id { get; set; }

        public Guid? InspectionId { get; set; }

        [Required]
        public DateTime InspectionDate { get; set; }

        [Required]
        public List<Guid> InspectedBy { get; set; }

        [Required]
        public int LocationFrom { get; set; }

        [Required]
        public int LocationTo { get; set; }

        [MaxLength(50)]
        public string LocationFromDesc { get; set; }

        [MaxLength(50)]
        public string LocationToDesc { get; set; }

        [Required]
        public Guid AT { get; set; }

        [Required]
        public Guid ST1 { get; set; }

        [Required]
        public Guid ST2 { get; set; }

        [Required]
        public Guid DefectType { get; set; }

        [Required]
        [StringLength(200)]
        public string DefectAction { get; set; }

        [Required]
        public Guid Priority { get; set; }

        [Required]
        public DateTime RepairDateDue { get; set; }

        public DateTime? RepairDate { get; set; }

        public Guid? RepairAssignee { get; set; }

        public string RepairComments { get; set; }

        public string Comments { get; set; }

        public Guid? Status { get; set; }

        public int? No { get; set; }
        public List<IFormFile> Files { get; set; }

        [Required]
        public Guid LocationPrefix { get; set; }
    }
}
