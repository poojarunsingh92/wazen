using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.QuoteResponses.Queries.GetQuoteResponseFromRedis
{
    public class GetQuoteResponseFromRedisQuery : IRequest<Response<RedisQuoteResponse>>
    {
        public Guid CustomerID { get; set; }
        public Guid VehicleID { get; set; }
        public string QuoteType { get; set; }
    }
}
