using System;
using System.Collections.Generic;
using System.Text;

namespace SMR.Tracking.Domain
{
    public class HiRailInspector: Audit
    {
        public Guid Id { get; set; }
        public Guid? HiRailInspectionId { get; set; }
        public HiRailInspection HiRailInspection { get; set; }

        public Guid? InspectorId { get; set; }
        public Inspector Inspector { get; set; }
    }
}
