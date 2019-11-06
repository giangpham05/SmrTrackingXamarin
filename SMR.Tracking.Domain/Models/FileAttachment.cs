using System;
using System.Collections.Generic;

namespace SMR.Tracking.Domain
{
    public class FileAttachment: Audit
    {
        public Guid Id { get; set; }
        public byte[] Attachment { get; set; }
        public string Filename { get; set; }
        public long Filesize { get; set; }
        public string Mimetype { get; set; }
        public Guid? DefectId { get; set; }
        public Defect Defect { get; set; }
    }
}
