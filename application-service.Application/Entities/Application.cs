using System;
using System.Collections.Generic;
using System.Globalization;
using Application.Service.Application.Handlers;

namespace Application.Service.Application.Entities
{
    public class Application
    {
        public string ApplicationId { get; init; }
        public string Status { get; init; }
        public IList<Individual> Parties { get; init; }
        public Business Business { get; init; } 
        public LoanRequest LoanRequest { get; init; }
    }
}

