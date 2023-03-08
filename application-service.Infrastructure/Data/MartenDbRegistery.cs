using System;
using Application.Service.Application.Entities;
using Marten;

namespace Application.Service.Infrastructure.Data
{
    public class MartenDbRegistery : MartenRegistry
    {
        public MartenDbRegistery()
        {
            For<Application.Entities.Application>()
                .Identity(x => x.ApplicationId)
                .DatabaseSchemaName("ApplicationService");
        }
    }
}

