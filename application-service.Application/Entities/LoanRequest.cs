using System;
namespace Application.Service.Application.Entities
{
    public class LoanRequest
    {
        public int Amount { get; set; }
        public int Term { get; set; }
        public LoanPurpose Purpose { get; set; }
        public ProductType ProductType { get; set; }
        public string Pitch { get; set; }
    }
}

