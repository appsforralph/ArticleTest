using ArticleTest.Common.Interface;
using ArticleTest.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ArticleTest.Controllers
{
    [Route("v1/")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly ILogger<ArticleController> _logger;
        private readonly IArticleService _articleService;
        public ArticleController(ILogger<ArticleController> logger, IArticleService articleService)
        {
            _logger = logger;
            _articleService = articleService;
        }

        [HttpGet]
        [Route("topArticles")]
        public async Task<BaseResponse> Get([FromQuery] BaseRequest req)
        {
            var articles = await _articleService.Get(req);
            var response = new BaseResponse()
            {
                results = articles.ToList(),
            };

            return response;
        }
    }
}
