using BlogAppV1.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppV1.ViewModels.SectionVms
{
    public class DetailedSectionVm
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long BlogId { get; set; }
        public long? PhotoId { get; set; }
        public int OwnerId { get; set; }
        public string OwnerUsername { get; set; }
        public IEnumerable<Posts> Posts { get; set; }
        public bool IsSystemCreated { get; set; }
    }
}
