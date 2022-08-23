using System;
using System.Collections.Generic;
using System.Text;

namespace WazenPolicy.Application.Features.Walaa.Commands.WalaaComprehensiveQuote
{
    public class WalaaComprehensiveQuoteResponse
    {
        public string ReferenceId { get; set; }
        public int StatusCode { get; set; }
        public string QuotationNo { get; set; }
        public DateTime QuotationDate { get; set; }
        public DateTime QuotationExpiryDate { get; set; }
        public List<Product> Products { get; set; }
        public List<Error> Errors { get; set; }
    }

    public class Product
    {
        public string ProductId { get; set; }
        public string ProductNameAr { get; set; }
        public string ProductNameEn { get; set; }
        public string ProductDescAr { get; set; }
        public string ProductDescEn { get; set; }
        public /*float*/string ProductPrice { get; set; }
        public int VehicleLimitValue { get; set; }
        public int DeductibleValue { get; set; }
        public List<PriceDetail> PriceDetails { get; set; }
        public List<Benefitt> Benefits { get; set; }
    }

    public class PriceDetail
    {
        public int PriceTypeCode { get; set; }
        public /*float*/ string PriceValue { get; set; }
        public /*float*/ string PercentageValue { get; set; }
    }

    public class Benefitt
    {
        public string BenefitId { get; set; }
        public string BenefitNameAr { get; set; }
        public string BenefitNameEn { get; set; }
        public string BenefitDescAr { get; set; }
        public string BenefitDescEn { get; set; }
        public float BenefitPrice { get; set; }
    }

    public class Error
    {
        public string Message { get; set; }
        public string Code { get; set; }
        public string Field { get; set; }
    }
}
