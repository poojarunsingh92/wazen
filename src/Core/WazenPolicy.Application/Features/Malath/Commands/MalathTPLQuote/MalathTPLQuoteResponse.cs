using System;
using System.Collections.Generic;
using System.Text;

namespace WazenPolicy.Application.Features.Malath.Commands.MalathTPLQuote
{
    public class MalathTPLQuoteResponse
    {
        public Guid RequestReferenceNo { get; set; }
        public int StatusCode { get; set; }
        public string QuotationNo { get; set; }
        public string QuotationDate { get; set; }
        public DateTime QuotationExpiryDate { get; set; }
        public List<Product> Products { get; set; }
        public List<Error> Error { get; set; }
    }

    public class Product
    {
        public string ProductId { get; set; }
        public decimal ProductPrice { get; set; }
        public int? ExcessValue { get; set; }
        public int? VehicleLimitValue { get; set; }
        public List<PriceDetail> PriceDetails { get; set; }
        public List<Cover> Covers { get; set; }
    }

    public class PriceDetail
    {
        public string PriceTypeCode { get; set; }
        public decimal PriceValue { get; set; }
        public decimal? PercentageValue { get; set; }
    }

    public class Cover
    {
        public int CoverCode { get; set; }
        public string CoverId { get; set; }
        public string CoverNameAr { get; set; }
        public string CoverNameEn { get; set; }
        public decimal CoverPrice { get; set; }
    }

    public class Error
    {
        public int Code { get; set; }
        public string Field { get; set; }
        public string Message { get; set; }
    }
}