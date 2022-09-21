using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI_WorkerService.Services.SendEnqueuedEmail
{
   
    public class SendEnqueuedEmailCommand : IRequest<bool?>
    {
    }
}
