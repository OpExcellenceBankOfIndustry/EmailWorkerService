using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI_WorkerService.Features.Mail.Command.EnqueueEmail
{
	public class EnqueueEmailCommand : IRequest<EnqueueEmailCommandResponse>
	{
		public string? Subject { get; set; }
		public string? Sender { get; set; }
		public string? ToRecipient { get; set; }
		public string? CcRecipient { get; set; }
		public string? BccRecipient { get; set; }
		public string? Message { get; set; }
		public bool IsHtml { get; set; }
		public string? Channel { get; set; }
		public bool HasAttachment { get; set; }
		public bool HasAlternateView { get; set; }

		public List<EnqueueEmailAttachmentsCommand>? EmailAttachments { get; set; }
	}
}
