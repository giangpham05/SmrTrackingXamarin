using System;

namespace SMR.Tracking.Domain
{
    public class DefectRepairLine: Audit
    {
        public Guid Id { get; set; }
        public Guid? InventoryId { get; set; }
        public Inventory Inventory { get; set; }
        public int? Quantity { get; set; }

        public Guid? DefectId { get; set; }
        public Defect Defect { get; set; }

        public Guid? RepaierId { get; set; }
        public Repairer Repairer { get; set; }
        public DateTime RepairDate { get; set; }
        public string RepairComment { get; set; }
    }
}
