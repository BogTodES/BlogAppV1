using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAppV1.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppV1.Controllers
{
    public class SectionController : Controller
    {
        private readonly SectionsService sectionsService;

        public SectionController(SectionsService sectionsService)
        {
            this.sectionsService = sectionsService;
        }


        public IActionResult ShowSectionDetails(long sectId, long blogId)
        {
            return View();
        }
    }
}
