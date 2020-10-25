using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppV1.ViewModels.HomeVms
{
    public class HomeSectionVm
    {
        public long SectId { get; set; }
        public long BlogId { get; set; }
        public long? PhotoId { get; set; }
        public int OwnerId { get; set; }
        public string OwnerUsername { get; set; }
        public string  SectTitle { get; set; }
    }
}
