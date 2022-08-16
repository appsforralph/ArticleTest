using ArticleTest.Common.Interface;
using ArticleTest.Model.DTO;
using ArticleTest.Services;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ArticleUnitTest
{
    public class ArticleServiceTest
    {
        private IArticleService _articleService;


        public ArticleServiceTest()
        {

            var articleDataList = DummyData();


            var _articleHttpClient = Mock.Of<IArticleHttpClient>(x =>
                x.Get(It.Is<BaseRequest>(req => req.Limit == 2)) == Task.FromResult(articleDataList)
            );

            var _casinologger = Mock.Of<ILogger<IArticleHttpClient>>();
            var _memoryCache = new MemoryCache(new MemoryCacheOptions());
            var _mapper = Mock.Of<IMapper>();


            _articleService = new ArticleService(_memoryCache, _articleHttpClient, _mapper);
        }

        [Fact]
        public async void Get_Should_ReturnData()
        {
            var req = new BaseRequest()
            {
                Limit = 2
            };

            var results = await _articleService.Get(req);
            Assert.True(results != null);

        }

        public ArticleResponse DummyData()
        {
            List<ArticleData> articleDataList = new List<ArticleData>();

            var article1 = new ArticleData()
            {
                title = "A Message to Our Customers",
                url = "http://www.apple.com/customer-letter/",
                author = "epaga",
                num_comments = 967,
                story_id = null,
                story_title = null,
                story_url = null,
                parent_id = null,
                created_at = 1455698317
            };
            var article2 = new ArticleData()
            {
                title = "“Was isolated from 1999 to 2006 with a 486. Built my own late 80s OS”",
                url = "http://imgur.com/gallery/hRf2trV",
                author = "epaga",
                num_comments= 265,
                  story_id= null,
                  story_title= null,
                  story_url= null,
                  parent_id= null,
                  created_at= 1418517626
            };
            articleDataList.Add(article1);
            articleDataList.Add(article2);
            var response = new ArticleResponse()
            {

                page = 1,
                per_page = 10,
                total = 2,
                total_pages = 1,
                data = articleDataList
            };

            
            return response;
        }
    }
}
