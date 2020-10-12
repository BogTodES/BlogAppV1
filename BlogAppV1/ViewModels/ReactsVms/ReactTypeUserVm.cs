using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppV1.ViewModels.ReactsVms
{
    public class ReactTypeUserVm
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public int ReactId { get; set; }
        public string Type { get; set; }
        public long? PostId { get; set; }
        public long? CommId { get; set; }
    }
}
