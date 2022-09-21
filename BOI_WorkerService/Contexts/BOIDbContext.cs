using BOI_WorkerService.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI_WorkerService.Contexts
{

    public class BOIDbContext : DbContext
    {
        public BOIDbContext(DbContextOptions<BOIDbContext> options)
            : base(options)
        {
        }


       
        public DbSet<Email> Emails { get; set; }
        public DbSet<EmailAttachment> EmailAttachments { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTimeOffset.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTimeOffset.UtcNow;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
