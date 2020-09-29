using BlogAppV1.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppV1.ViewModels.BlogStuff
{
    public class SmallSectionVm
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<Posts> Posts { get; set; }

        // umple asta cu date si afiseaza-l in viewComponent
    }
}
