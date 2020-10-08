using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppV1.ViewModels.ReactsVms
{
    public class ReactsAndCommVm
    {
        public IEnumerable<ReactTypeUserVm> TypesAndUsers { get; set; }
        public long CommId { get; set; }
    }
}
