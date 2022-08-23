using System;
using System.Collections.Generic;
using System.Text;

namespace WazenPolicy.Application.Features.QuoteResponses.Queries.GetQuoteResponseFromRedis
{
    public class NCDEligiblityResponseRedis
    {
        public int statusCode { get; set; }
        public string ncdReference { get; set; }
        public int ncdFreeYears { get; set; }
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
    }
}
