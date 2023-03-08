using System.Threading;
using System.Threading.Tasks;
using BoltOn.Cache;
using BoltOn.Data;
using BoltOn.Data.MartenDb;
using BoltOn.Logging;
using BoltOn.Requestor;
using Application.Service.Application.DTOs;
using Application.Service.Application.Entities;
using System.Collections.Generic;
using Application.Service.Application.Mapping;
using FluentValidation;
using Application.Service.Application.Validation;
using OneOf;
using System;

namespace Application.Service.Application.Handlers
{
    public class CreateApplicationRequest : IRequest<OneOf<ApplicationDto, ValidationFailed>>
    {
        public string Status { get; set; }
        public IList<IndividualDto> Parties { get; set; }
        public BusinessDto Business { get; set; }
        public LoanRequestDto LoanRequest { get; set; }
        public string CacheKey => "Applications";
    }

    public class CreateApplicationHandler : IHandler<CreateApplicationRequest, OneOf<ApplicationDto, ValidationFailed>>
    {
        private readonly IRepository<Entities.Application> _applicationRepository;
        private readonly IAppLogger<CreateApplicationHandler> _logger;
        private readonly IValidator<CreateApplicationRequest> _validator;

        public CreateApplicationHandler(IRepository<Entities.Application> applicationRepository,
            IAppLogger<CreateApplicationHandler> logger, IValidator<CreateApplicationRequest> validator)
        {
            _applicationRepository = applicationRepository;
            _logger = logger;
            _validator = validator;
        }

        public async Task<OneOf<ApplicationDto, ValidationFailed>> HandleAsync(CreateApplicationRequest request, CancellationToken cancellationToken)
        {
            _logger.Debug("Validate Application...");
            var validationResult = _validator.Validate(request);
            if(!validationResult.IsValid)
            {
                return new ValidationFailed(validationResult.Errors);
            }
            _logger.Debug("Creating Application...");
            var appRequest = request.ToApplication();
            var application = await _applicationRepository.AddAsync(appRequest, cancellationToken: cancellationToken);
            var ApplicationDto = application.ToApplicationDto();
            return ApplicationDto;
        }
    }
}
