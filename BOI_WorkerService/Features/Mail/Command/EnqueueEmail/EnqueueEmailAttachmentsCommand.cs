using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI_WorkerService.Features.Mail.Command.EnqueueEmail
{
    public class EnqueueEmailAttachmentsCommand
    {
        public string? Attachment { get; set; }
        public string? ContentType { get; set; }
        public string? FileName { get; set; }
    }
}
