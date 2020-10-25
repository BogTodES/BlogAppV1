using BlogAppV1.ViewModels.HomeVms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppV1.ViewModels.Home
{
    public class HomeResultsVm
    {
        public List<HomeBlogVm> BlogResults { get; set; }
        public List<HomePostVm> PostResults { get; set; }
        public List<HomeSectionVm> SectionResults { get; set; }
    }
}
