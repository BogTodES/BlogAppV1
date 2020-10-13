using BlogAppV1.DataAccess;
using BlogAppV1.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppV1.ViewModels.SearchVms
{
    public class SearchResult
    {
        public string Keyword { get; set; }
        public string ObjectType { get; set; }
        public string ObjectInfo { get; set; }

        /*public string MainInfo { get; set; }
        public string MyProperty { get; set; }*/

        public SearchResult(string Keyword, string ObjectType)
        {
            this.Keyword = Keyword;
            this.ObjectType = ObjectType;
        }

    }
}
