using System;
using System.Linq;
using System.Collections.Generic;
using Application.Service.Application.DTOs;
using Application.Service.Application.Entities;
using Application.Service.Application.Handlers;

namespace Application.Service.Application.Mapping
{
    public static class RequestToDto 
    {
        public static ApplicationDto ToApplicationDto(this UpdateApplicationRequest updateApplicationRequest)
        {
            return new ApplicationDto
            {
                ApplicationId = updateApplicationRequest.ApplicationId,
                Status = updateApplicationRequest.Status,
                Parties = updateApplicationRequest.Parties,
                Business = updateApplicationRequest.Business,
                LoanRequest = updateApplicationRequest.LoanRequest
            };
        }
    }
}

