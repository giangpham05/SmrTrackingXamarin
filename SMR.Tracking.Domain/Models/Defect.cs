using System;
using System.Collections.Generic;

namespace SMR.Tracking.Domain
{
    public class Defect: Audit
    {
        public Guid Id { get; set; }
        public int No { get; set; }
        public Guid? WalkByInspectionId { get; set; }
        public WalkByInspection WalkByInspection { get; set; }
        public DateTime InspectionDate { get; set; }
        public ICollection<DefectInspector> DefectInspectors { get; set; }
        public ICollection<FileAttachment> FileAttachments { get; set; }
        public ICollection<DefectRepairLine> DefectRepairLines { get; set; }
        public int LocationFrom { get; set; }
        public int LocationTo { get; set; }
        public string LocationFromDesc { get; set; }
        public string LocationToDesc { get; set; }
        public AT At { get; set; }
        public Guid? AtId { get; set; }
        public ST1 St1 { get; set; }
        public Guid? St1Id { get; set; }
        public ST2 St2 { get; set; }
        public Guid? St2Id { get; set; }
        public DefectType DefectType { get; set; }
        public Guid? DefectTypeId { get; set; }
        public string DefectAction { get; set; }
        public Priority Priority { get; set; }
        public Guid? PriorityId { get; set; }
        public DateTime RepairDateDue { get; set; }
        public DateTime? RepairDate { get; set; }
        public Repairer Repairer { get; set; }
        public Guid? RepairerId { get; set; }
        public string RepairComments { get; set; }
        public string Comments { get; set; }
        public Status Status { get; set; }
        public Guid? StatusId { get; set; }
        public LocationPrefix LocationPrefix { get; set; }
        public Guid? LocationPrefixId { get; set; }
    }
}
