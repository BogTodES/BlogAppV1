using BlogAppV1.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppV1.ViewModels
{
    public class DetailedBlogVm
    {
        // datele blogului si cateva date despre owner

        public long BlogId { get; set; }
        public string Title { get; set; }
        public IEnumerable<long> SectionsIds { get; set; }
        public string OwnerUsername { get; set; }
        public string OwnerEmail { get; set; }
        public int OwnerId { get; set; }

        public DetailedBlogVm(Blogs blog, IEnumerable<long> sectionIds, UserInfoVm owner)
        {
            BlogId = blog.Id;
            Title = blog.Title;
            SectionsIds = sectionIds;
            OwnerUsername = owner.Username;
            OwnerId = owner.Id;
            OwnerEmail = owner.Email;
        }
    }
}
