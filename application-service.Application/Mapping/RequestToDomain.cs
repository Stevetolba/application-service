using System;
using System.Linq;
using System.Collections.Generic;
using Application.Service.Application.DTOs;
using Application.Service.Application.Entities;
using Application.Service.Application.Handlers;

namespace Application.Service.Application.Mapping
{
    public static class RequestToDomain 
    {
        public static Entities.Application ToApplication(this CreateApplicationRequest createApplicationRequest, string applicationId = null)
        {
            var parties = from i in createApplicationRequest.Parties
                          select i.ToIndividual();

            return new Entities.Application
            {
                ApplicationId = applicationId ?? Guid.NewGuid().ToString(),
                Status = createApplicationRequest.Status,
                Parties = parties.ToList(),
                Business =createApplicationRequest.Business.ToBusiness(),
                LoanRequest = createApplicationRequest.LoanRequest.ToLoanRequest()
            };
        }

        public static Entities.Application ToApplication(this UpdateApplicationRequest updateApplicationRequest)
        {
            var parties = from i in updateApplicationRequest.Parties
                          select i.ToIndividual();

            return new Entities.Application
            {
                ApplicationId = updateApplicationRequest.ApplicationId,
                Status = updateApplicationRequest.Status,
                Parties = parties.ToList(),
                Business = updateApplicationRequest.Business.ToBusiness(),
                LoanRequest = updateApplicationRequest.LoanRequest.ToLoanRequest()
            };
        }
    }
}

