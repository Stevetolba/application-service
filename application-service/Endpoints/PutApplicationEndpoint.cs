using System;
using Microsoft.AspNetCore.Authorization;
using FastEndpoints;
using BoltOn.Requestor;
using Application.Service.Application.DTOs;
using Application.Service.Application.Handlers;
using System.Threading;
using Application.Service.Application.Validation;
using OneOf;
using OneOf.Types;

namespace Application.Service.Endpoints
{
    public class PutApplicationRequest
    {
        [FromBody]
        public UpdateApplicationRequest? ApplicationData { get; set; }
    }

    [HttpPut("/applications/{ApplicationId}"), AllowAnonymous]
    public class PutApplicationsEndpoint : Endpoint<PutApplicationRequest>
    {
        private readonly IRequestor _requestor;

        public PutApplicationsEndpoint(IRequestor requestor)
        {
            _requestor = requestor;
        }

        public override async Task HandleAsync(PutApplicationRequest request, CancellationToken cancellationToken)
        {
            var result = await _requestor.ProcessAsync(request.ApplicationData, cancellationToken);
            await result.Match(
                m => SendAsync(m, cancellation: cancellationToken),
                _ => SendNotFoundAsync(),
                failed => SendAsync(failed));
        }
    }
}
