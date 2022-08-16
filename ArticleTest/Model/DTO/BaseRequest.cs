using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleTest.Model.DTO
{
    public class BaseRequest
    {
        private int limitPerPage;
        private int _maxlimitPerPage = 25;


        public int Limit
        {
            get => limitPerPage;
            set => limitPerPage = value > _maxlimitPerPage ? _maxlimitPerPage : value;
        }
        public int PageNumber { get; set; } = 1;
    }
}
