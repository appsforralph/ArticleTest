using ArticleTest.Common.Interface;
using ArticleTest.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using ArticleTest.Common.Settings;
using Microsoft.Extensions.Options;

namespace ArticleTest.Common.HttpClient
{
    public class ArticleHttpClient : IArticleHttpClient
    {
        private readonly System.Net.Http.HttpClient _client;
        private readonly ILogger<ArticleHttpClient> _logger;
        private readonly AppSettings _settings;

        public ArticleHttpClient(System.Net.Http.HttpClient client, ILogger<ArticleHttpClient> logger, IOptionsSnapshot<AppSettings> settings)
        {
            _client = client;
            _logger = logger;
            _settings = settings.Value;

        }

        public async Task<ArticleResponse> Get(BaseRequest req)
        {
            try
            {
                var requestUrl = "api/articles?page=" + req.PageNumber;

                var response = await _client.GetAsync(requestUrl);

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<ArticleResponse>();
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occured fetching ArticleResponse from the Article API, could be un supported parameter or bad url.");
                _logger.LogDebug(ex.ToString());

                // Return empty.
                return new ArticleResponse();

            }
        }
    }
}
