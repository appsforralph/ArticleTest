using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleTest.Model.DTO
{
    public class BaseResponse
    {
        public int page { get; set; }
        public List<ArticleData> results { get; set; }
    }
}
