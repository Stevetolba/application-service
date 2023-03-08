using System;
using Microsoft.AspNetCore.Authorization;
using FastEndpoints;
using BoltOn.Requestor;
using Application.Service.Application.DTOs;
using Application.Service.Application.Handlers;
using System.Threading;

namespace Application.Service.Endpoints
{
    
    [HttpGet("/applications"), AllowAnonymous]
    public class GetApplicationsEndpoint :Endpoint<GetAllApplicationsRequest, IEnumerable<ApplicationDto>>
	{
        private readonly IRequestor _requestor;
        
        public GetApplicationsEndpoint(IRequestor requestor)
		{
            _requestor = requestor;            
        }

        public override async Task HandleAsync(GetAllApplicationsRequest request, CancellationToken cancellationToken)
        {
            var applications = await _requestor.ProcessAsync(new GetAllApplicationsRequest(), cancellationToken);            
            await SendOkAsync(applications, cancellation: cancellationToken);
        }
     }
}
