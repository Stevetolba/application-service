using System;
using System.Threading;
using System.Threading.Tasks;
using BoltOn.Cache;
using BoltOn.Data.MartenDb;
using BoltOn.Logging;
using BoltOn.Requestor;
using Application.Service.Application.Entities;
using Application.Service.Application.DTOs;
using System.Collections.Generic;
using Application.Service.Application.Mapping;
using Application.Service.Application.Validation;
using OneOf;
using OneOf.Types;
using FluentValidation;

namespace Application.Service.Application.Handlers
{
	public class UpdateApplicationRequest : IRequest<OneOf<ApplicationDto, NotFound, ValidationFailed>>
	{
		public string ApplicationId { get; set; }
        public string Status { get; set; }
        public IList<IndividualDto> Parties { get; set; }
        public BusinessDto Business { get; set; }
        public LoanRequestDto LoanRequest { get; set; }
        public string CacheKey => "Applications";
	}

	public class UpdateApplicationHandler : IHandler<UpdateApplicationRequest, OneOf<ApplicationDto, NotFound, ValidationFailed>>
	{
		private readonly IRepository<Entities.Application> _ApplicationRepository;
		private readonly IAppLogger<UpdateApplicationHandler> _logger;
        private readonly IValidator<UpdateApplicationRequest> _validator;

        public UpdateApplicationHandler(IRepository<Entities.Application> ApplicationRepository,
			IAppLogger<UpdateApplicationHandler> logger, IValidator<UpdateApplicationRequest> validator)
		{
			_ApplicationRepository = ApplicationRepository;
			_logger = logger;
			_validator = validator;
		}

		public async Task<OneOf<ApplicationDto, NotFound, ValidationFailed>> HandleAsync(UpdateApplicationRequest request, CancellationToken cancellationToken)
		{
            _logger.Debug("Validate updating Application...");
			var validationResult = _validator.Validate(request);
			if(!validationResult.IsValid)
			{
				return new ValidationFailed(validationResult.Errors);
			}
            _logger.Debug("Updating Application...");
			var application = await _ApplicationRepository.GetByIdAsync(request.ApplicationId, cancellationToken: cancellationToken);
			if(application==null)
			{
				return new NotFound();
			}
			await _ApplicationRepository.UpdateAsync(request.ToApplication(), cancellationToken: cancellationToken);
			return request.ToApplicationDto(); ;
		}
	}
}
