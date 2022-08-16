using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleTest.Model.DTO
{
    public class ArticleResponse
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<ArticleData> data { get; set; }
    }

    public class ArticleData
    {
        public string title { get; set; }
        public string url { get; set; }
        public string author { get; set; }
        public int? num_comments { get; set; }
        public object story_id { get; set; }
        public string story_title { get; set; }
        public string story_url { get; set; }
        public int? parent_id { get; set; }
        public int created_at { get; set; }
    }
}
