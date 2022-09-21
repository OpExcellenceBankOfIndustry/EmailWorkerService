using AutoMapper;
using BOI_WorkerService.Entities;
using BOI_WorkerService.Exceptions;
using BOI_WorkerService.Persistence.Mail;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI_WorkerService.Features.Mail.Command.EnqueueEmail
{
    public class EnqueueEmailCommandHandler : IRequestHandler<EnqueueEmailCommand, EnqueueEmailCommandResponse>
    {
        private readonly IEmailRepository _emailRepository;
        private readonly IMapper _mapper;

        public EnqueueEmailCommandHandler(IEmailRepository emailRepository, IMapper mapper)
        {
            _emailRepository = emailRepository;
            _mapper = mapper;
        }
        public async Task<EnqueueEmailCommandResponse> Handle(EnqueueEmailCommand request, CancellationToken cancellationToken)
        {
            var validator = new EnqueueEmailValidators();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
                throw new CustomValidationException(validationResult);

            var insertedEmail = await _emailRepository.AddAsync(_mapper.Map<Email>(request));

            return new EnqueueEmailCommandResponse
            {
                Message = "Email submitted successfully",
                Success = true,
                EnqueueEmailViewModel = _mapper.Map<EnqueueEmailViewModel>(insertedEmail)

            };
        }
    }
}
