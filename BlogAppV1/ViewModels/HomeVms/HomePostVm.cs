using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppV1.ViewModels.HomeVms
{
    public class HomePostVm
    {
        public long PostId { get; set; }
        public long SectId { get; set; }
        public long? PhotoId { get; set; }
        public string PostTitle { get; set; }
        public string PostBody { get; set; }
        public string SectTitle { get; set; }
        public int OwnerId { get; set; }
        public string OwnerUsername { get; set; }
    }
}
