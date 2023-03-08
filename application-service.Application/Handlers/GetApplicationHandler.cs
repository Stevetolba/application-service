using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BoltOn.Data.MartenDb;
using BoltOn.Logging;
using BoltOn.Requestor;
using Application.Service.Application.DTOs;
using Application.Service.Application.Entities;
using Application.Service.Application.Mapping;

namespace Application.Service.Application.Handlers
{
    public class GetApplicationRequest : IRequest<ApplicationDto>
    {
        public string ApplicationId { get; set; }
    }

    public class GetApplicationHandler : IHandler<GetApplicationRequest, ApplicationDto>
    {
        private readonly IRepository<Entities.Application> _applicationRepository;
        private readonly IAppLogger<GetApplicationHandler> _logger;
        
        public GetApplicationHandler(IRepository<Entities.Application> applicationRepository,
            IAppLogger<GetApplicationHandler> logger)
        {
            _applicationRepository = applicationRepository;
            _logger = logger;
        }

        public async Task<ApplicationDto> HandleAsync(GetApplicationRequest request, CancellationToken cancellationToken)
        {
            _logger.Debug("Getting application...");
            var application = (await _applicationRepository.FindByAsync(f => f.ApplicationId == request.ApplicationId,
                cancellationToken: cancellationToken)).FirstOrDefault();
            var applicationDto = application.ToApplicationDto();
            return applicationDto;
        }
    }
}
