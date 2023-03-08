using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BoltOn.Cache;
using BoltOn.Data;
using BoltOn.Data.MartenDb;
using BoltOn.Requestor;
using Application.Service.Application.DTOs;
using Application.Service.Application.Entities;
using Application.Service.Application.Mapping;
using BoltOn.Logging;

namespace Application.Service.Application.Handlers
{
    public class GetAllApplicationsRequest : IRequest<IEnumerable<ApplicationDto>>
    {
        public string CacheKey => "Applications";
    }

    public class GetAllApplicationsHandler : IHandler<GetAllApplicationsRequest, IEnumerable<ApplicationDto>>
    {
        private readonly IRepository<Entities.Application> _applicationRepository;
        private readonly IAppLogger<GetAllApplicationsHandler> _logger;

        public GetAllApplicationsHandler(IRepository<Entities.Application> applicationRepository,
            IAppLogger<GetAllApplicationsHandler> logger)
        {
            _applicationRepository = applicationRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<ApplicationDto>> HandleAsync(GetAllApplicationsRequest request,
            CancellationToken cancellationToken = default)
        {
            _logger.Debug("Getting all applications...");
            var applications = await _applicationRepository.GetAllAsync(cancellationToken: cancellationToken);
            var applicationsDto =  from i in applications select i.ToApplicationDto();
            return applicationsDto;
        }
    }
}
