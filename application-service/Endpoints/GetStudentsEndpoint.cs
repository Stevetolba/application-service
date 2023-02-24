using System;
using Microsoft.AspNetCore.Authorization;
using FastEndpoints;
using BoltOn.Requestor;
using Application.Service.Application.DTOs;
using Application.Service.Application.Handlers;
using System.Threading;

namespace Application.Service.Endpoints
{
    
    [HttpGet("/students"), AllowAnonymous]
    public class GetStudentsEndpoint :Endpoint<GetAllStudentsRequest, IEnumerable<StudentDto>>
	{
        private readonly IRequestor _requestor;
        
        public GetStudentsEndpoint(IRequestor requestor)
		{
            _requestor = requestor;            
        }

        public override async Task HandleAsync(GetAllStudentsRequest request, CancellationToken cancellationToken)
        {
            var students = await _requestor.ProcessAsync(new GetAllStudentsRequest(), cancellationToken);            
            await SendAsync(students, cancellation: cancellationToken);
        }
     }
}
