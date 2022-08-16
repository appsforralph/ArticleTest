using ArticleTest.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleTest.Common.Interface
{
    public interface IArticleService
    {
        Task<IEnumerable<ArticleData>> Get(BaseRequest req);
    }
}
