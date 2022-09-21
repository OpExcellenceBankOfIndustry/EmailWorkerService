using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI_WorkerService.Features.Mail.Command.EnqueueEmail
{
    public class EnqueueEmailCommandResponse : BaseResponse
    {
        public EnqueueEmailCommandResponse() : base()
        {

        }

        public EnqueueEmailViewModel EnqueueEmailViewModel { get; set; }
    }
}
