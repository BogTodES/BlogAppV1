using BlogAppV1.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppV1.ViewModels.Home
{
    public class HomeBlogVm
    {
        public long BlogId { get; set; }
        public string BlogTitle { get; set; }
        public int OwnerId { get; set; }
        public string OwnerUsername { get; set; }
        public long? PhotoId { get; set; }
        public IEnumerable<Sections> Sections { get; set; }
    }
}
