using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI_WorkerService.Models.ConfigurationModels
{
    public class ServiceConfigurationSettings
    {
        public int RunningPeriod { get; set; }
        public string? EmployeeFolderPath { get; set; }
        public string? BonitaServerIPAddress { get; set; }
        public string? BonitaWebUrl { get; set; }
        public string? SendBonitaAvailabilityTo { get; set; }
        public bool ActivateEnqueueEmail { get; set; }
    }
}
