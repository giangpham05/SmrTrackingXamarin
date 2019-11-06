using System;

namespace SMR.Tracking.Domain
{
    public class LocationIncrement: Audit
    {
        public Guid Id { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public Guid? LocationPrefixId { get; set; }
        public LocationPrefix LocationPrefix { get; set; }
    }
}
