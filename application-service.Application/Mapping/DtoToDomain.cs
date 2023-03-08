using System;
using Application.Service.Application.DTOs;
using Application.Service.Application.Entities;

namespace Application.Service.Application.Mapping
{
	public static class DtotToDomain
	{
        public static PersonalTaxId ToPersonalTaxId(this PersonalTaxIdDto personalTaxIdDto)
        {
            return new PersonalTaxId
            {
                Number = personalTaxIdDto.Number,
                IsSocialSecurityNumber = personalTaxIdDto.IsSocialSecurityNumber
            };
        }

        public static Individual ToIndividual(this IndividualDto individualDto)
        {
            return new Individual
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
                TaxId = individualDto.TaxId.ToPersonalTaxId()
            };
        }

        public static BusinessTaxId ToBusinessTaxId(this BusinessTaxIdDto businessTaxIdDto)
        {
            return new BusinessTaxId
            {
                Number = businessTaxIdDto.Number,
                IsEmployerIdentificationNumber = businessTaxIdDto.IsEmployerIdentificationNumber
            };
        }

        public static Business ToBusiness(this BusinessDto businessDto)
        {
            return new Business
            {

                Name = businessDto.Name,
                DoingBusinessAs = businessDto.DoingBusinessAs,
                StreetAddressLine1 = businessDto.StreetAddressLine1,
                StreetAddressLine2 = businessDto.StreetAddressLine2,
                City = businessDto.City,
                StateCode = businessDto.StateCode,
                ZipCode = businessDto.ZipCode,
                PhoneNumber = businessDto.PhoneNumber,
                EntityType = businessDto.EntityType,
                AnnualSales = businessDto.AnnualSales,
                OutstandingDebtAmount = businessDto.OutstandingDebtAmount,
                NaicsCode = businessDto.NaicsCode,
                StartDate = businessDto.StartDate,
                IsNonProfit = businessDto.IsNonProfit,
                BusinessTaxId = businessDto.BusinessTaxId.ToBusinessTaxId()
            };
        }

        public static LoanRequest ToLoanRequest(this LoanRequestDto loanRequestDto)
        {
            return new LoanRequest
            {
                Amount = loanRequestDto.Amount,
                Term = loanRequestDto.Term,
                Purpose = loanRequestDto.Purpose,
                ProductType = loanRequestDto.ProductType,
                Pitch = loanRequestDto.Pitch
            };
        }
    }
}

