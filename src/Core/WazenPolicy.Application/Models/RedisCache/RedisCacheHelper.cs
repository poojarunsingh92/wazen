using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WazenPolicy.Application.Models.RedisCache
{
    public static class RedisCacheHelper
    {
        public static T GetHelper<T>(this IDistributedCache cache, string cacheKey)
        {
            return Deserialize<T>(cache.Get(cacheKey));
        }

        public static object GetHelper(this IDistributedCache cache, string cacheKey)
        {
            return Deserialize<object>(cache.Get(cacheKey));
        }

        public static void SetHelper(this IDistributedCache cache, string cacheKey, object cacheValue)
        {
             
            cache.Set(cacheKey, Serialize(cacheValue));
        }

        private static byte[] Serialize (object obj)
        {
            if (obj == null)
            {
                return null;
            }
            BinaryFormatter objBinaryFormatter = new BinaryFormatter();
            using (MemoryStream objMemoryStream = new MemoryStream())
            {
                objBinaryFormatter.Serialize(objMemoryStream, obj);
                byte[] objDataAsByte = objMemoryStream.ToArray();
                return objDataAsByte;
            }
        }

        private static T Deserialize<T>(byte[] bytes)
        {
            BinaryFormatter objBinaryFormatter = new BinaryFormatter();
            if (bytes == null)
                return default(T);

            using (MemoryStream objMemoryStream = new MemoryStream(bytes))
            {
                T result = (T)objBinaryFormatter.Deserialize(objMemoryStream);
                return result;
            }
        }

        public static async Task SetRecordAsync<T>(this IDistributedCache cache,
           string recordId,
           T data )
        {
             

            var jsonData = JsonSerializer.Serialize(data);
            await cache.SetStringAsync(recordId, jsonData);
        }

        public static async Task<T> GetRecordAsync<T>(this IDistributedCache cache, string recordId)
        {
            var jsonData = await cache.GetStringAsync(recordId);

            if (jsonData is null)
            {
                return default(T);
            }

            return JsonSerializer.Deserialize<T>(jsonData);
        }
    }
}
