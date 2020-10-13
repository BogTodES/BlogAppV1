using BlogAppV1.DataAccess;
using BlogAppV1.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppV1.ViewModels.SearchVms
{
    public class BlogSearchResult : SearchResult
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string OwnerName { get; set; }
        public int OwnerId { get; set; }

        public BlogSearchResult(string Keyword, Blogs Blog, UserNoPass Owner)
            : base(Keyword, "BlogResult")
        {
            this.Id = Blog.Id;
            this.Title = Blog.Title;
            this.OwnerId = Owner.Id;
            this.OwnerName = Owner.Username;

            ObjectInfo = System.Text.Json.JsonSerializer
                .Serialize(new { BlogId = Id, Title = Title, OwnerId = OwnerId, OwnerName = OwnerName });
        }
    }
}
