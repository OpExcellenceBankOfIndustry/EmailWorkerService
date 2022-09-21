using BOI_WorkerService.Contexts;
using BOI_WorkerService.Entities;
using BOI_WorkerService.Persistence.Mail;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI_WorkerService.Repository.Mail
{
    public class EmailRepository : BaseRepository<Email>, IEmailRepository
    {
        public EmailRepository(BOIDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Email>> GetPendingEnquedEmail()
        {
            var allPendingEmails = await _dbContext.Emails.Where(x => x.Sent == false).OrderBy(x => x.EmailId).ToListAsync();
            return allPendingEmails;
        }
    }
}
