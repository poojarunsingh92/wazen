using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WazenPolicy.Application.Contracts.Persistence;
using WazenPolicy.Application.Models.RedisCache;

namespace WazenPolicy.Application.Features.QuoteResponses.Queries.GetQuoteResponseFromRedis
{
    public class RedisDataConnection<T> where T : class
    {
        private readonly IAsyncRepository<T> _baseRepository;
        private IDistributedCache _cache;
        public RedisDataConnection(IAsyncRepository<T> baseRepository, IDistributedCache cache)
        {
            _baseRepository = baseRepository;
            _cache = cache;
        }
        public async Task<List<T>> RedisData(string cacheKey)
        {
            List<T> data = new List<T>();
            try
            {
                data = await this._cache.GetRecordAsync<List<T>>(cacheKey);
                if (data == null)
                {
                    data = await _baseRepository.GetListAllAsync();
                    await this._cache.SetRecordAsync(cacheKey, data);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message.ToString());
            }
            return data;
        }
    }
}
