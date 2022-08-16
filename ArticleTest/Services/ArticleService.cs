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

        public async Task<IEnumerable<string>> Get(BaseRequest req)
        {
            ArticleResponse result;
            List<ArticleData> articleList;
            int pageNumber = 1;
            IEnumerable<string> response = null;

            var key = new { req.Limit }.GetHashCode();

            //Added cache set for 10mins
            if (_memoryCache.TryGetValue(key, out response)) 
                return response;
            result = await _articleHttpClient.Get(req);
            articleList = result.data.ToList();
            pageNumber++;

            //get the total pages
            while (pageNumber <= result.total_pages)
            {
                result = null;
                req.PageNumber = pageNumber;
                result = await _articleHttpClient.Get(req);
                articleList.AddRange(result.data.ToList());
                pageNumber++;
            }

            response = articleList
                .Where(d =>
                    (d.title != null ? true : (d.story_title != null ? true : false))
                ).OrderByDescending(c => c.num_comments).ThenBy(n => n.title)
                .Take(req.Limit)
                .Select(s =>
                   (s.title != null ? s.title : (s.story_title != null ? s.story_title : null))
                );


            _memoryCache.Set(key, response, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(10)));

            return response;
        }

    }
}
