using System;
using Microsoft.AspNetCore.Authorization;
using FastEndpoints;
using BoltOn.Requestor;
using Application.Service.Application.DTOs;
using Application.Service.Application.Handlers;
using System.Threading;

namespace Application.Service.Endpoints
{

    public class GetApplicationRequest
    {
        [FromHeader(IsRequired = false, HeaderName = "x-user-id")]
        public string? UserId { get; set; }

        public string? ApplicationId { get; set; }
    }

    [HttpGet("/applications/{applicationId}"), AllowAnonymous]
    public class GetApplicationEndpoint : Endpoint<GetApplicationRequest, ApplicationDto>
    {
        private readonly IRequestor _requestor;

        public GetApplicationEndpoint(IRequestor requestor)
        {
            _requestor = requestor;
        }

        public override async Task HandleAsync(GetApplicationRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.ApplicationId))
            {
                throw new ArgumentException("ApplicationId cannot be empty");
            }
            var getAppRequesrt = new Application.Handlers.GetApplicationRequest { ApplicationId = request.ApplicationId };
            var application = await _requestor.ProcessAsync(getAppRequesrt, cancellationToken);
            await SendOkAsync(application, cancellation: cancellationToken);
        }
    }
}
