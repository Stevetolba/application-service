using System;
using Microsoft.AspNetCore.Authorization;
using FastEndpoints;
using BoltOn.Requestor;
using Application.Service.Application.DTOs;
using Application.Service.Application.Handlers;
using System.Threading;

namespace Application.Service.Endpoints
{
    public class PostStudentRequest
    {
        [FromBody]
        public CreateStudentRequest? StudentData { get; set; }
    }

    [HttpPost("/students"), AllowAnonymous]
    public class PostStudentsEndpoint :Endpoint<PostStudentRequest, StudentDto>
	{
        private readonly IRequestor _requestor;
        
        public PostStudentsEndpoint(IRequestor requestor)
		{
            _requestor = requestor;            
        }

        public override async Task HandleAsync(PostStudentRequest request, CancellationToken cancellationToken)
        {
            var student = await _requestor.ProcessAsync(request.StudentData, cancellationToken);            
            await SendAsync(student, cancellation: cancellationToken);
        }
     }
}
