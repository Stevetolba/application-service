using System;
using Microsoft.AspNetCore.Authorization;
using FastEndpoints;
using BoltOn.Requestor;
using Application.Service.Application.DTOs;
using Application.Service.Application.Handlers;
using System.Threading;
using Application.Service.Application.Validation;
using OneOf;

namespace Application.Service.Endpoints
{
    public class PostApplicationRequest
    {
        [FromBody]
        public CreateApplicationRequest? ApplicationData { get; set; }
    }

    [HttpPost("/applications"), AllowAnonymous]
    public class PostApplicationsEndpoint : Endpoint<PostApplicationRequest>
    {
        private readonly IRequestor _requestor;

        public PostApplicationsEndpoint(IRequestor requestor)
        {
            _requestor = requestor;
        }

        public override async Task HandleAsync(PostApplicationRequest request, CancellationToken cancellationToken)
        {
            var result = await _requestor.ProcessAsync(request.ApplicationData, cancellationToken);
            await result.Match(
                m =>  SendAsync(m, cancellation: cancellationToken),
                failed => SendAsync(failed));
        }
    }
}
