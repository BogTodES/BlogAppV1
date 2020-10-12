using BlogAppV1.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppV1.ViewModels.SearchVms
{
    public class SectionSearchResult : SearchResult
    {
        public string Name { get; set; }
        public IEnumerable<Blogs> Blogs { get; set; }

        public SectionSearchResult(string Keyword, Sections Section, IEnumerable<Blogs> Blogs)
            : base(Keyword, "SectionResult")
        {
            this.Name = Section.Name;
            this.Blogs = Blogs;
        }
    }
}
