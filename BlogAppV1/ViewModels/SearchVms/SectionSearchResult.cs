using BlogAppV1.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppV1.ViewModels.SearchVms
{
    public class SectionSearchResult : SearchResult
    {
        public long SectId { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Blogs { get; set; }

        public SectionSearchResult(string Keyword, Sections Section, IEnumerable<Blogs> Blogs)
            : base(Keyword, "SectionResult")
        {
            this.SectId = Section.Id;
            this.Name = Section.Name;
            this.Blogs = Blogs.Select(b => b.Title);

            ObjectInfo = System.Text.Json.JsonSerializer
                .Serialize(new { SectId = SectId, Name = Name, Blogs = this.Blogs });
        }
    }
}
