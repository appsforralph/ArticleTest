using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleTest.Model.DTO
{
    public class BaseRequest
    {

        public int Limit { get; set; } = 1;
        public int PageNumber { get; set; } = 1;
    }
}
