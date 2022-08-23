using System;
using System.Collections.Generic;
using System.Text;

namespace WazenPolicy.Application.Features.ACIG.Command.ACIGTPLQuote
{
    public class ACIGTPLQuoteResponse
    {
        public string customerid { get; set; }
        public string QuoteRequestRefNo { get; set; }
        public Boolean Status { get; set; }
        public List<Error> Errors { get; set; }
        public List<Quote> Quote { get; set; }
    }

    public class Quote
    {
        public string QuotationNo { get; set; }
        public string Product { get; set; }
        public List<PremiumDetails> PremiumDetails { get; set; }
        public List<AdditionalCover> AdditionalCovers { get; set; }
    }
    public class PremiumDetails
    {
        public int? Deductable { get; set; }
        public double GrossPremium { get; set; }
        public double TotalDiscount { get; set; }
        public double PremiumExcVat { get; set; }
        public double TotalTax { get; set; }
        public double TotalPremium { get; set; }
        public List<PremiumBreakdown> PremiumBreakdown { get; set; }
        public List<DiscountBreakdown> DiscountBreakdown { get; set; }
    }

    public class AdditionalCover
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

    public class Error
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
    }
}
