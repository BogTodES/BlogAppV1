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
        public long? PhotoId { get; set; }

    }
}
