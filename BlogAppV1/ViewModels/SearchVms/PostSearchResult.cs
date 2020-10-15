using BlogAppV1.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppV1.ViewModels.SearchVms
{
    public class PostSearchResult : SearchResult
    {
        public long PostId { get; set; }
        public string Title { get; set; }
        public string ShortBody { get; set; }
        public long SectId { get; set; }
        public int MyProperty { get; set; }

        public PostSearchResult(string Keyword, Posts Post, Blogs Blog) : 
            base(Keyword, "PostResult")
        {
        }
    }
}
