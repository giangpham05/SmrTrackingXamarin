using SMR.Tracking.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMR.Tracking.Domain
{
    public class Audit
    {
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
