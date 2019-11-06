using System;
using System.Collections.Generic;
using System.Text;

namespace SMR.Tracking.Domain
{
    public class DefectInspector: Audit
    {
        public Guid Id { get; set; }
        public Guid? DefectId { get; set; }
        public Defect Defect { get; set; }

        public Guid? InspectorId { get; set; }
        public Inspector Inspector { get; set; }
    }
}
