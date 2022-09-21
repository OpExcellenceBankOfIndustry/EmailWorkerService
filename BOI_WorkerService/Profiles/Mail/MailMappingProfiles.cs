using AutoMapper;
using BOI_WorkerService.Entities;
using BOI_WorkerService.Features.Mail.Command.EnqueueEmail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI_WorkerService.Profiles.Mail
{
    public class MailMappingProfiles : Profile
    {
        public MailMappingProfiles()
        {
            CreateMap<EnqueueEmailCommand, Email>()
            .BeforeMap((eque, e) => e.DateLogged = DateTimeOffset.UtcNow)
            .ReverseMap();

            CreateMap<Email, EnqueueEmailViewModel>()
            .ReverseMap();

            CreateMap<EnqueueEmailAttachmentsCommand, EmailAttachment>()
            .ForMember(
                dest => dest.Attachment,
                opt => opt.MapFrom(src => (src.Attachment == null) ? null : Encoding.ASCII.GetBytes(src.Attachment))
                )
            .ReverseMap();

            CreateMap<EmailAttachment, EnqueueEmailAttachmentsViewModel>().ReverseMap();


            CreateMap<Email, EmailRequest>().ReverseMap();

            CreateMap<EmailAttachment, EmailAttachmentRequest>().ReverseMap();
        }
    }
}
