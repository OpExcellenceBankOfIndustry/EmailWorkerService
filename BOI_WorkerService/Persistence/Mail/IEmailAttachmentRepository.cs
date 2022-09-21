using BOI_WorkerService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI_WorkerService.Persistence.Mail
{
    public interface IEmailAttachmentRepository : IAsyncRepository<EmailAttachment>
    {
    }
}
