using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI_WorkerService.Models.ConfigurationModels
{
    public class EmailConfigurationSettings
    {
        public string EmailFrom { get; set; }
        public string SmtpHost { get; set; }
        public string SmtpPassword { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUser { get; set; }
        public string BankName { get; set; }

    }
}
