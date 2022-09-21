using BOI_WorkerService.Contexts;
using BOI_WorkerService.Entities;
using BOI_WorkerService.Persistence.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI_WorkerService.Repository.Mail
{
    public class EmailAttachmentRepository : BaseRepository<EmailAttachment>, IEmailAttachmentRepository
    {
        public EmailAttachmentRepository(BOIDbContext dbContext) : base(dbContext)
        {

        }
    }
}
