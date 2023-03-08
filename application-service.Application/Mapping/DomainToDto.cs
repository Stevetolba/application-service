using System;
using System.Linq;
using Application.Service.Application.DTOs;
using Application.Service.Application.Entities;
using Application.Service.Application.Handlers;

namespace Application.Service.Application.Mapping
{
    public static class DomainToDto
    {
        public static PersonalTaxIdDto ToPersonalTaxIdDto(this PersonalTaxId personalTaxId)
        {
            return new PersonalTaxIdDto
            {
                Number = personalTaxId.Number,
                IsSocialSecurityNumber = personalTaxId.IsSocialSecurityNumber
            };
        }

        public static IndividualDto ToIndividualDto(this Individual individualDto)
        {
            return new IndividualDto
            {

                FirstName = individualDto.FirstName,
                LastName = individualDto.LastName,
                StreetAddressLine1 = individualDto.StreetAddressLine1,
                StreetAddressLine2 = individualDto.StreetAddressLine2,
                City = individualDto.City,
                StateCode = individualDto.StateCode,
                ZipCode = individualDto.ZipCode,
                EmailAddress = individualDto.EmailAddress,
                MobilePhoneNumber = individualDto.MobilePhoneNumber,
                DateOfBirth = individualDto.DateOfBirth,
                HouseholdIncome = individualDto.HouseholdIncome,
                IsControlPerson = individualDto.IsControlPerson,
                TaxId = individualDto.TaxId.ToPersonalTaxIdDto()
            };
        }

        public static BusinessTaxIdDto ToBusinessTaxIdDto(this BusinessTaxId businessTaxId)
        {
            return new BusinessTaxIdDto
            {
                Number = businessTaxId.Number,
                IsEmployerIdentificationNumber = businessTaxId.IsEmployerIdentificationNumber
            };
        }

        public static BusinessDto ToBusinessDto(this Business business)
        {
            return new BusinessDto
            {

                Name = business.Name,
                DoingBusinessAs = business.DoingBusinessAs,
                StreetAddressLine1 = business.StreetAddressLine1,
                StreetAddressLine2 = business.StreetAddressLine2,
                City = business.City,
                StateCode = business.StateCode,
                ZipCode = business.ZipCode,
                PhoneNumber = business.PhoneNumber,
                EntityType = business.EntityType,
                AnnualSales = business.AnnualSales,
                OutstandingDebtAmount = business.OutstandingDebtAmount,
                NaicsCode = business.NaicsCode,
                StartDate = business.StartDate,
                IsNonProfit = business.IsNonProfit,
                BusinessTaxId = business.BusinessTaxId.ToBusinessTaxIdDto()
            };
        }

        public static LoanRequestDto ToLoanRequestDto(this LoanRequest loanRequest)
        {
            return new LoanRequestDto
            {
                Amount = loanRequest.Amount,
                Term = loanRequest.Term,
                Purpose = loanRequest.Purpose,
                ProductType = loanRequest.ProductType,
                Pitch = loanRequest.Pitch
            };
        }

        public static ApplicationDto ToApplicationDto(this Entities.Application application)
        {
            var partiesDto = from i in application.Parties
                             select i.ToIndividualDto();
            return new ApplicationDto
            {
                ApplicationId = application.ApplicationId,
                Status = application.Status,
                Parties = partiesDto.ToList(),
                Business = application.Business.ToBusinessDto(),
                LoanRequest = application.LoanRequest.ToLoanRequestDto()
            };
        }
    }
}

