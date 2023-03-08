using System;

namespace Application.Service.Application.Entities
{
    public class Business
    {
        public string Name { get; set; }
        public string DoingBusinessAs { get; set; }
        public string StreetAddressLine1 { get; set; }
        public string StreetAddressLine2 { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public EntityType EntityType { get; set; }
        public long AnnualSales { get; set; }
        public long OutstandingDebtAmount { get; set; }
        public int NaicsCode { get; set; }
        public string StartDate { get; set; }
        public bool IsNonProfit { get; set; }
        public BusinessTaxId BusinessTaxId { get; set; }
    }
}

