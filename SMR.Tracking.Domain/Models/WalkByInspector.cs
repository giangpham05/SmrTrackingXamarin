using System;

namespace SMR.Tracking.Domain
{
    public class WalkByInspector: Audit
    {
        public Guid Id { get; set; }
        public Guid? WalkByInspectionId { get; set; }
        public WalkByInspection WalkByInspection { get; set; }

        public Guid? InspectorId { get; set; }
        public Inspector Inspector { get; set; }
    }
}