using System;
namespace Application.Service.Application
{
    public enum EntityType : ushort
    {
        LimitedLiabilityCompany = 1,
        Partnership = 2,
        SoleProprietor = 3,
        SCorporation = 4,
        CCorporation = 5
    }

    public enum LoanPurpose : ushort
    {
        BusinessExpansion = 1,
        CashCrunch = 2,
        DebtRefinancing = 3,
        EquipmentPurchase = 4,
        InventoryPurchase = 5,
        MarketingCampaign = 6,
        MeetPayroll = 7,
        RenovationsCapitalImprovements = 8,
        WorkingCapital = 9
    }

    public enum ProductType : ushort
    {
        TermLoan = 1,
        LineOfCredit = 2
    }
}

