using BlogAppV1.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppV1.ViewModels.PostVms
{
    public class PostDetails
    {
        public long Id { get; set; }
        public long SectId { get; set; }
        public int OwnerId { get; set; }
        public string OwnerUsername { get; set; }
        public IEnumerable<Comments> Comments { get; set; }
    }
}
