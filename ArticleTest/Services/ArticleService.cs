using ArticleTest.Common.Interface;
using ArticleTest.Model.DTO;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleTest.Services
{
    public class ArticleService : IArticleService
    {
        public IArticleHttpClient _articleHttpClient;
        public IMapper _mapper;
        public IMemoryCache _memoryCache;
        public ArticleService(IMemoryCache memoryCache, IArticleHttpClient articleHttpClient, IMapper mapper)
        {
            _articleHttpClient = articleHttpClient;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<IEnumerable<ArticleData>> Get(BaseRequest req)
        {
            ArticleResponse result;
            IEnumerable<ArticleData> response = null;

            var key = new { req.PageNumber }.GetHashCode();

            //Added cache set for 10mins
            if (_memoryCache.TryGetValue(key, out result)) return response;
            result = await _articleHttpClient.Get(req);

            response = result.data;
            _memoryCache.Set(key, response, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(10)));

            return response;
        }

    }
}
