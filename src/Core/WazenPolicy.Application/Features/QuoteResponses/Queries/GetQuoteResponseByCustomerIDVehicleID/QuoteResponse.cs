using System;
using System.Collections.Generic;
using System.Text;

namespace WazenPolicy.Application.Features.QuoteResponses.Queries.GetQuoteResponseByCustomerIDVehicleID
{
    public class QuoteResponse
    {
        public string customerid { get; set; }       

        public List<Quote> Quote { get; set; }
    }

    public class Quote
    {
        public Guid ICID { get; set; }
        public Guid vehicleId { get; set; }
        public string QuoteRequestRefNo { get; set; }
        public string QuotationNo { get; set; }
        public string product { get; set; }
        public string companyName { get; set; }
        public List<PremiumDetails> premiumDetails { get; set; }
    }

    public class PremiumDetails
    {
        public int? deductable { get; set; }
        public double GrossPremium { get; set; }
        public double TotalDiscount { get; set; }
        public double PremiumExcVat { get; set; }
        public double TotalTax { get; set; }
        public double TotalPremium { get; set; }
        public List<AdditionalCovers> additionalCovers { get; set; }
        public List<PremiumBreakdown> premiumBreakdown { get; set; }
        public List<DiscountBreakdown> discountBreakdowns { get; set; }
    }

    public class AdditionalCovers
    {
        public string FeatureCode { get; set; }
        public string FeatureDesc { get; set; }
        public double FeatureAmount { get; set; }
        public double TaxAmount { get; set; }
    }

    public class PremiumBreakdown
    {
        public string TypeCode { get; set; }
        public double Amount { get; set; }
        public double Percentage { get; set; }
    }

    public class DiscountBreakdown
    {
        public string TypeCode { get; set; }
        public double Amount { get; set; }
        public double Percentage { get; set; }
    }
}
