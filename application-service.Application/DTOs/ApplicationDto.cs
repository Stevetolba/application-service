using System;
using Application.Service.Application.Entities;
using System.Collections.Generic;
using System.Globalization;

namespace Application.Service.Application.DTOs
{
    public class ApplicationDto
    {
        public string ApplicationId { get; set; }
        public string Status { get; set; }
        public IList<IndividualDto> Parties { get; set; }
        public BusinessDto Business { get; set; } = new BusinessDto();
        public LoanRequestDto LoanRequest { get; set; } = new LoanRequestDto();

        public string DisplayLoanRequest =>
            LoanRequest.ProductType == ProductType.TermLoan
                ? $"{LoanRequest.Amount.ToString("C", CultureInfo.CurrentCulture)} Term Loan; {LoanRequest.Term} months"
                : $"{LoanRequest.Amount.ToString("C", CultureInfo.CurrentCulture)} Line of Credit";
    }
}
