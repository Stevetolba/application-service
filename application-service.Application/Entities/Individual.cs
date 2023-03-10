using System;
namespace Application.Service.Application.Entities
{
    public class Individual
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddressLine1 { get; set; }
        public string StreetAddressLine2 { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string ZipCode { get; set; }
        public string EmailAddress { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string DateOfBirth { get; set; }
        public long HouseholdIncome { get; set; }
        public bool IsControlPerson { get; set; }
        public PersonalTaxId TaxId { get; set; }
    }
}

