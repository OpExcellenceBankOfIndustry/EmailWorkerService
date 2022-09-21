using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI_WorkerService.Entities
{
    public class EmailAttachment
    {
        public int EmailAttachmentId { get; set; }
        public byte[]? Attachment { get; set; }
        public string? ContentType { get; set; }
        public string? FileName { get; set; }
    }
}
