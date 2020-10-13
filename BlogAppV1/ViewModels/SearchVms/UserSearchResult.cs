using BlogAppV1.DataAccess;
using BlogAppV1.Entities.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace BlogAppV1.ViewModels.SearchVms
{
    public class UserSearchResult : SearchResult
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public IEnumerable<string> Blogs { get; set; }

        public UserSearchResult(string Keyword, UserNoPass User, IEnumerable<Blogs> Blogs) 
            : base(Keyword, "UserResult")
        {
            this.Username = User.Username;
            this.Email = User.Email;
            this.Id = User.Id;
            this.Blogs = Blogs.Select(b => b.Title);

            ObjectInfo = System.Text.Json.JsonSerializer
                .Serialize(new { UserId = Id, Username = Username, Email = Email, Blogs = this.Blogs });
        }
    }
}
